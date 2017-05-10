using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMedium : MonoBehaviour {

    public int life;
    public double XP; //Asignar experiencia-------000000000000000----------------
    public Animator anim;
    public float defaultSpeed;
    public double attackDistance;
    public AudioClip hurt;

    private Transform enemySprite;
    private Transform target;
    private bool dead;
    private AudioSource source;

	private bool invincible;

    void Awake()
    {
    	source = GetComponent<AudioSource>();
    }

    void Start()
    {
		invincible = false;
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
				source.PlayOneShot(hurt);

				if (!invincible && life >= 1) {
					anim.SetBool("moving", false);
					StartCoroutine (invincibility ());
					anim.SetTrigger ("hurt");
				}
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
	private IEnumerator invincibility() {
		invincible = true;

		yield return new WaitForSeconds (2f);

		invincible = false;
	}
}
