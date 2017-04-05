using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateSpawn : MonoBehaviour {

	private miniBossController parent;
	private Vector3[] spawns;
	private int currentSpawn;
	private float defaultSpeed;
	private Transform enemySprite;

	// Use this for initialization
	void Start () {
		defaultSpeed = 3.5f;
		parent = (miniBossController)FindObjectOfType(typeof(miniBossController));
		spawns = parent.spawns;
		enemySprite = transform.GetChild (0);
	}
	
	// Update is called once per frame
	void Update () {

		//transform.Translate (spawns[currentSpawn]);
		//parent.anim.SetTrigger ("pow");

		AnimatorStateInfo currentState = parent.anim.GetCurrentAnimatorStateInfo(0);

		Vector3 movement = (spawns[currentSpawn] - this.transform.position).normalized * Time.deltaTime * defaultSpeed;

		if (movement.x > 0) {
			enemySprite.transform.rotation = Quaternion.Euler (0, 180, 0);
		}
		if (movement.x < 0) {
			enemySprite.transform.rotation = Quaternion.Euler (0, 0, 0);
		}

		if ( 0.5f < Mathf.Abs (Vector3.Distance (this.transform.position, spawns[currentSpawn])) ) {

			parent.anim.SetBool ("moving", true);
			this.transform.Translate (movement);

		} else if( !currentState.IsName("pow") ){

			parent.anim.SetBool ("moving", false);
			parent.anim.SetTrigger ("pow");
			currentSpawn = (currentSpawn + 1) % 3;
		}	
	}
}
