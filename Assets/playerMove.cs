using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour {
	public Animator anim;
	public Transform sprite;
    public string inputAxis;

	private float speed;
	public float DEFAULT_SPEED = 2;
	private float speedMultiplier; //if we use a speedBoost item

	private float oldAtk;
	private float oldAtk2;
	private float oldAtk3;

	// Use this for initialization
	void Start () {
		oldAtk = 0;
		oldAtk2 = 0;
		oldAtk3 = 0;
		speedMultiplier = 1;
		speed = DEFAULT_SPEED;
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis ("Horizontal"+inputAxis);
		float v = Input.GetAxis ("Vertical" + inputAxis);
		float atk = Input.GetAxis ("Fire1" + inputAxis);
		float atk2 = Input.GetAxis ("Fire2" + inputAxis);
		float atk3 = Input.GetAxis ("Fire3" + inputAxis);

		AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo (0);

		if ( currentState.IsName("player_atk") || currentState.IsName("player_atk2") || currentState.IsName("player_atk3") ) {
			oldAtk = 1;
			oldAtk2 = 1;
			oldAtk3 = 1;
			speed = 0;
		} else {
			speed = DEFAULT_SPEED * speedMultiplier;
		}

		if (atk == 1 && oldAtk == 0) {
			anim.SetTrigger ("atk");
			Debug.Log ("Attack");
		}


		if (atk2 == 1 && oldAtk2 == 0) {
			anim.SetTrigger ("atk2");
			Debug.Log ("Attack");
		}

		if (atk3== 1 && oldAtk3 == 0) {
			anim.SetTrigger ("atk3");
			Debug.Log ("Attack");
		}

		if (h > 0) {
			sprite.transform.rotation = Quaternion.Euler (0, 180, 0);
		}
		if (h < 0) {
			sprite.transform.rotation = Quaternion.Euler (0, 0, 0);
		}

		anim.SetFloat ("walk", Mathf.Abs(h) + Mathf.Abs(v));
		Vector3 v3 = new Vector3 (h, 0, v);
		transform.Translate (v3.normalized * speed * Time.deltaTime);

		oldAtk  = atk;
		oldAtk2 = atk2;
		oldAtk3 = atk3;
	}
}
