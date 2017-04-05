using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniBossController : MonoBehaviour {

	public float life;
    public float XP;
	public Vector3[] spawns;
	//public GameObject minion;
	public Animator anim;
	//public float defaultSpeed;
	//public double attackDistance;

	private State current;
	private Symbol close, far, low, time,midclose;
	private MonoBehaviour currentBehavior;
	private Coroutine timecounter;

	private bool dead;

	// Use this for initialization
	void Start () {
        life = 100;
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
		wait.AddNeighbor (close, attack);
		wait.AddNeighbor (low, spawn);

		current = wait;

		currentBehavior = (MonoBehaviour)gameObject.AddComponent (current.Behavior);
		StartCoroutine (CheckSymbols());
		timecounter =  StartCoroutine (CountTime ());
	}

	IEnumerator CheckSymbols() {



		while (true) {


			State temp = null;

			if (life < 30) {
				temp = current.ApplySymbol (low);
                //continue;
			}
            else if(Vector3.Distance(FindClosest().position, transform.position) < 6)
            {
                temp = current.ApplySymbol(far);
                if(Vector3.Distance(FindClosest().position, transform.position) < 3)
                {
                    temp = current.ApplySymbol(midclose);
                }else if(Vector3.Distance(FindClosest().position, transform.position) < 1)
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
			dead = true;
			GameController.addExp (this.XP);
			anim.SetTrigger("dead");
			//Destroy(this);
		}
		else if(c.gameObject.layer == 9 && !dead)
		{
			anim.SetTrigger("hurt");
			life--;
		}

	}

	public Transform FindClosest() {

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

		return dummy.transform;
	}
}
