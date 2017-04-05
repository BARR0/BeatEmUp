using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEasy : MonoBehaviour {

	public int life;
	public Animator anim;
	public float defaultSpeed;
	public double attackDistance;

	private Transform enemySprite;
	private Transform target;
	private bool dead;

	void Start () {
		enemySprite = transform.GetChild (0);

		//Init first target
		target = GameController.players [0].gameObject.transform;
		Physics.IgnoreLayerCollision ( 10, 12);
		dead = false;
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

		if ( attackDistance < Mathf.Abs (Vector3.Distance (this.transform.position, target.position)) && !currentState.IsName ("dead") ) {

			anim.SetBool ("moving", true);
			this.transform.Translate (movement);

		} else if( !currentState.IsName("attack") && !currentState.IsName ("dead")){
			
			anim.SetBool ("moving", false);
			anim.SetTrigger ("atk");
		}

		if (life < 1 && !dead) {

			dead = true;
			anim.SetTrigger ("dead");
		}
			

	}

	IEnumerator FindClosestTarget() {

		while (true) {

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

			target = dummy.transform;

			yield return new WaitForSeconds (1);
		}
	}

	void OnTriggerEnter(Collider co) {
		
		if ( co.gameObject.layer == 9) {
			
			life--;
		}
	}

}
