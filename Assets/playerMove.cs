using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
	public const float DEFAULT_SPEED = 2;

	public Animator anim;
	public Transform sprite;
    public string inputAxis;
	public int life;

	private float speed;
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
		this.inputAxis = GameController.controllers [this.gameObject];
		GameController.addPlayer (this);
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis ("Horizontal"+inputAxis);
		float v = Input.GetAxis ("Vertical" + inputAxis);
		float atk = Input.GetAxis ("Fire1" + inputAxis);
		float atk2 = Input.GetAxis ("Fire2" + inputAxis);
		float atk3 = Input.GetAxis ("Fire3" + inputAxis);
		//Debug.Log (this.gameObject.name + ": " + atk + atk2 + atk3 + "");

		AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo (0);

		if ( currentState.IsName("player_atk") || currentState.IsName("player_atk2") || currentState.IsName("player_atk3") || currentState.IsName("player_hurt")) {
			oldAtk = 1;
			oldAtk2 = 1;
			oldAtk3 = 1;
			speed = 0;
		} else {
			speed = DEFAULT_SPEED * speedMultiplier;
			if (h > 0) {
				sprite.transform.rotation = Quaternion.Euler (0, 180, 0);
			}
			if (h < 0) {
				sprite.transform.rotation = Quaternion.Euler (0, 0, 0);
			}
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

		anim.SetFloat ("walk", Mathf.Abs(h) + Mathf.Abs(v));
		Vector3 v3 = new Vector3 (h, 0, v);
		transform.Translate (v3.normalized * speed * Time.deltaTime);

		oldAtk  = atk;
		oldAtk2 = atk2;
		oldAtk3 = atk3;
	}

	void OnTriggerEnter (Collider c) {
		if (life > 0) {
			life--;
			if (c.gameObject.layer == 9) {
				anim.SetTrigger ("hurt");
			}
		} else {
			//CapsuleCollider playerCol = this.GetComponent<CapsuleCollider> ();
			//playerCol.enabled = false;
			anim.SetTrigger ("dead");
		}
	}
}
