using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class darklordbehaviour : MonoBehaviour {

    public int life;
    public double XP; //Asignar experiencia-------000000000000000----------------
    public Animator anim;
    public float defaultSpeed;
    public double attackDistance;
    public Camera cameraWithController;
    public AudioClip hurt;

    private double musicDistance;
    private Transform enemySprite;
    private Transform target;
    private bool dead;
    private bool musicOn;
    private AudioSource source;

    void Awake()
    {
    	source = GetComponent<AudioSource>();
    }

    void Start()
    {
        musicOn = false;
        musicDistance = 7;
        enemySprite = transform.GetChild(0);
        //life = 10;

        //Init first target
        target = GameController.players[0].gameObject.transform;
        Physics.IgnoreLayerCollision(10, 12);
        dead = false;
        StartCoroutine(FindClosestTarget());
    }

    // Update is called once per frame
    void Update()
    {

        AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo(0);
        //Debug.Log(life);
		if (target == null)
			return;
        Vector3 movement = (target.position - this.transform.position).normalized * Time.deltaTime * defaultSpeed;

        if (movement.x > 0)
        {
            enemySprite.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (movement.x < 0)
        {
            enemySprite.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if(musicDistance >= Mathf.Abs(Vector3.Distance(this.transform.position, target.position)) && !musicOn)
        {
            cameraWithController.GetComponent<Level3Controller>().BossEncounter();
            musicOn = true;
        }

        if (!currentState.IsName("atk") && !currentState.IsName("hurt") && attackDistance < Mathf.Abs(Vector3.Distance(this.transform.position, target.position)) && !dead)
        {

            anim.SetBool("moving", true);
            this.transform.Translate(movement);

        }
        if (!currentState.IsName("atk") && !currentState.IsName("hurt") && attackDistance >= Mathf.Abs(Vector3.Distance(this.transform.position, target.position)) && !dead)
        {

            anim.SetBool("moving", false);
            anim.SetTrigger("atk");
        }
    }

    void OnTriggerEnter(Collider c)
    {
        
        if (c.gameObject.layer == 9 && !dead)
        {
            int damageTaken = GameController.ApplyDamage(c.transform.root.tag);
            if (damageTaken > 0)
            {
                life -= damageTaken;
                anim.SetBool("moving", false);
                source.PlayOneShot(hurt);
                if (life >= 1)
                    anim.SetTrigger("hurt");
            }
        }
		if (c.gameObject.layer == 9 && life < 1 && !dead)
		{
			dead = true;
			GameController.addExp (this.XP);
			anim.SetTrigger("dead");
			StartCoroutine(WhenNotDestroyed());
		}

    }

    IEnumerator FindClosestTarget() {

		while (true) {
			if(GameController.players.Count <= 0) break;
			PlayerController dummy = GameController.players [0];
			float mindist = dummy.life / (float) dummy.maxlife;

			foreach (PlayerController go in GameController.players) {

				float distDummy = go.life / (float) go.maxlife;

				//Iterates through players to find the shortest one
				if ( distDummy < mindist) {

					mindist = distDummy;
					dummy = go;
				}

			}

			target = dummy.transform;

			yield return new WaitForSeconds (1);
		}
	}
    IEnumerator WhenNotDestroyed()
    {

        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}
