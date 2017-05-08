using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAttack : MonoBehaviour {

	private float defaultSpeed;
	private double atkDist;
	private Transform enemySprite;
	private Transform target;
	private miniBossController parent;

	// Use this for initialization
	void Start () {
		parent = (miniBossController)FindObjectOfType(typeof(miniBossController));
		enemySprite = transform.GetChild (0);
		target = parent.FindClosest ();
		defaultSpeed = 2;
		atkDist = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {

		AnimatorStateInfo currentState = parent.anim.GetCurrentAnimatorStateInfo(0);
		if (target == null)
			return;
		Vector3 movement = (target.position - this.transform.position).normalized * Time.deltaTime * defaultSpeed;

		if (movement.x > 0) {
			enemySprite.transform.rotation = Quaternion.Euler (0, 180, 0);
		}
		if (movement.x < 0) {
			enemySprite.transform.rotation = Quaternion.Euler (0, 0, 0);
		}

		if ( atkDist < Mathf.Abs (Vector3.Distance (this.transform.position, target.position)) ) {

			parent.anim.SetBool ("moving", true);
			this.transform.Translate (movement);

		} else if( !currentState.IsName("atk") ){

			parent.anim.SetBool ("moving", false);
			parent.anim.SetTrigger ("atk");
		}	
		
	}
}
