using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMedium : MonoBehaviour {

	public int life;
	public Animator anim;
	public float defaultSpeed;
	public double attackDistance;

	private Transform enemySprite;
	private Transform target;

	void Start () {
		enemySprite = transform.GetChild (0);

		//Init first target
		target = GameController.players [0].gameObject.transform;
		StartCoroutine ( FindClosestTarget() );
	}

	// Update is called once per frame
	void Update () {

		AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo (0);

		Vector3 movement = (target.position - this.transform.position).normalized * Time.deltaTime * defaultSpeed;

		if (movement.x > 0) {
			enemySprite.transform.rotation = Quaternion.Euler (0, 180, 0);
		}
		if (movement.x < 0) {
			enemySprite.transform.rotation = Quaternion.Euler (0, 0, 0);
		}

		if ( attackDistance < Mathf.Abs (Vector3.Distance (this.transform.position, target.position)) ) {

			anim.SetBool ("moving", true);
			this.transform.Translate (movement);

		} else if( !currentState.IsName("attack") ){

			anim.SetBool ("moving", false);
			anim.SetTrigger ("atk");
		}

		print (this.gameObject.name + " : " + target.gameObject.name);
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
