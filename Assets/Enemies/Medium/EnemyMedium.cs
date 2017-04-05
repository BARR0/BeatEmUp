using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMedium : MonoBehaviour {

    public int life;
    public double XP; //Asignar experiencia-------000000000000000----------------
    public Animator anim;
    public float defaultSpeed;
    public double attackDistance;

    private Transform enemySprite;
    private Transform target;
    private bool dead;

    void Start()
    {
        enemySprite = transform.GetChild(0);
        life = 10;

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
        Debug.Log(life);
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

        if (attackDistance < Mathf.Abs(Vector3.Distance(this.transform.position, target.position)) && !dead)
        {

            anim.SetBool("moving", true);
            this.transform.Translate(movement);

        }
        else if (!currentState.IsName("atk") && !dead)
        {

            anim.SetBool("moving", false);
            anim.SetTrigger("atk");
        }
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
        else if (c.gameObject.layer == 9 && !dead)
        {
            //anim.SetTrigger("hurt");
            life--;
        }

    }

    IEnumerator FindClosestTarget() {

		while (true) {

			PlayerController dummy = GameController.players [0];
			float mindist = dummy.life;

			foreach (PlayerController go in GameController.players) {

				float distDummy = go.life;

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
}
