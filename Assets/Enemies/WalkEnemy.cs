using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkEnemy : MonoBehaviour {

	public Animator anim;
	public Transform sprite;
	public Transform p1,
	                 p2,
	                 p3,
	                 p4;
	public float defaultSpeed;
	public double minDistance;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Transform closest = p1;
		if(Vector3.Distance(this.transform.position, p2.position) < Vector3.Distance(this.transform.position, closest.position)) {
			closest = p2;
		}
		if(Vector3.Distance(this.transform.position, p3.position) < Vector3.Distance(this.transform.position, closest.position)) {
			closest = p3;
		}
		if(Vector3.Distance(this.transform.position, p3.position) < Vector3.Distance(this.transform.position, closest.position)) {
			closest = p4;
		}
		AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo (0);

		//Vector3 movement = Vector3.MoveTowards(this.transform.position, closest.position, defaultSpeed * Time.deltaTime);
		Vector3 movement = (closest.position - this.transform.position).normalized * Time.deltaTime * defaultSpeed;
		if (movement.x - this.transform.position.x > 0) {
			sprite.transform.rotation = Quaternion.Euler (0, 180, 0);
		}
		if (movement.x - this.transform.position.x < 0) {
			sprite.transform.rotation = Quaternion.Euler (0, 0, 0);
		}

		if (minDistance < Mathf.Abs (Vector3.Distance (this.transform.position, closest.position))) {
			// Debug.Log ((this.transform.position - closest.position) * Time.deltaTime);
			//Vector3 movement = (closest.position - this.transform.position).normalized;
			// movement *= Mathf.Abs(Vector3.Distance (this.transform.position, closest.position)) > 0 ? 1 : -1;
			anim.SetBool ("moving", true);
			// this.transform.position = movement;
			this.transform.Translate (movement);
		} else if(!currentState.IsName("attack")){
			anim.SetBool ("moving", false);
			anim.SetTrigger ("atk");
		}
	}
}
