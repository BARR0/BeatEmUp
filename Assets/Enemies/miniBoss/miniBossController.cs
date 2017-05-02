using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class miniBossController : MonoBehaviour {

	public float life;
    public float XP;
	public Vector3[] spawns;
	//public GameObject minion;
	public Animator anim;
    public AudioClip hurt;
	//public float defaultSpeed;
	//public double attackDistance;

	private State current;
	private Symbol close, far, low, time,midclose;
	private MonoBehaviour currentBehavior;
	private Coroutine timecounter;
    private AudioSource source;

	public Camera contlvl;
	private bool musicOn;

	private bool dead;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }
	// Use this for initialization
	void Start () {
		midclose = new Symbol ("midclose");
		close = new Symbol("close");
		far = new Symbol ("far");
		low = new Symbol ("low");
		time = new Symbol ("time");

		State attack = new State ("attack", typeof(StateAttack));
		State spawn = new State ("spawn", typeof(StateSpawn));

		State wait = new State ("wait", typeof(StateWait));

		//attack.AddNeighbor (far, walk);
		attack.AddNeighbor (low, spawn);
		attack.AddNeighbor (time, spawn);
		//attack.AddNeighbor (midclose, walk);

		spawn.AddNeighbor (close, attack);
		spawn.AddNeighbor (time, attack);

		//wait.AddNeighbor (midclose, walk);
		wait.AddNeighbor (far, attack);
		wait.AddNeighbor (close, attack);
		wait.AddNeighbor (low, spawn);

		current = wait;

		currentBehavior = (MonoBehaviour)gameObject.AddComponent (current.Behavior);
		StartCoroutine (CheckSymbols());
		timecounter =  StartCoroutine (CountTime ());
		dead = false;
		musicOn = false;
	}

	IEnumerator CheckSymbols() {

		while (true) {

			Transform tmp = FindClosest ();
			if (tmp == null)
				break;
			float curretnDist = Vector3.Distance (tmp.position, transform.position);
			print (curretnDist);

			State temp = null;

			if (life < 30) {
				temp = current.ApplySymbol (low);
                //continue;
			}
			else if(curretnDist < 6)
            {
				if (!musicOn) {
					musicOn = true;
					contlvl.GetComponent<Level2Controller> ().BossEncounter ();
				}

                temp = current.ApplySymbol(far);
				if(curretnDist < 4)
                {
                    temp = current.ApplySymbol(midclose);
				}else if(curretnDist < 2)
                {
                    temp = current.ApplySymbol(close);
                }
            }

			if (temp != null && temp != current) {
				StopCoroutine (timecounter);
				timecounter = StartCoroutine (CountTime ());
				current = temp;
				Destroy (currentBehavior);
				currentBehavior = (MonoBehaviour)gameObject.AddComponent (current.Behavior);
			}

			yield return new WaitForSeconds (1);
		}
	}

	IEnumerator CountTime() {
		
		while (true) {
			
			yield return new WaitForSeconds (6);
			State temp = current.ApplySymbol (time);
			current = temp;
			Destroy (currentBehavior);
			currentBehavior = (MonoBehaviour)gameObject.AddComponent (current.Behavior);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider c)
	{
		if (life < 1 && !dead)
		{
			Destroy (currentBehavior);
			dead = true;
			GameController.addExp (this.XP);
			anim.SetTrigger("dead");
            StartCoroutine(WhenDestroyed());
        }
		else if(c.gameObject.layer == 9 && !dead)
		{
            life--;
            source.PlayOneShot(hurt);
            anim.SetTrigger("hurt");
		}

	}

	public Transform FindClosest() {
		if (GameController.players.Count <= 0)
			return null;
		GameObject dummy = GameController.players [0].gameObject;
		float mindist = Vector3.Distance (this.gameObject.transform.position, dummy.transform.position);

		foreach (PlayerController go in GameController.players) {

			float distDummy = Vector3.Distance (this.gameObject.transform.position, go.gameObject.transform.position);
			//Iterates through players to find the shortest one
			if ( distDummy < mindist) {

				mindist = distDummy;
				dummy = go.gameObject;
			}

		}
		if (dummy == null)
			return null;
		return dummy.transform;
	}

    IEnumerator WhenDestroyed()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("Game Over");
        //Destroy(this.gameObject);
    }
}
