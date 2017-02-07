using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour {
	public Animator anim;
	public Transform hijo;
	public float speed;

	private float oldFire;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		float fire = Input.GetAxis ("Fire1");

		if (fire == 1 && oldFire == 0) {
			anim.Play ("player_atk");
			Debug.Log ("Attack");
		}

		if ((h != 0 || v != 0)) {

			anim.SetBool ("isWalking", true);

			if (h > 0) {
				hijo.transform.rotation = Quaternion.Euler (0, 180, 0);
			}
			if (h < 0) {
				hijo.transform.rotation = Quaternion.Euler (0, 0, 0);
			}

			Vector3 v3 = new Vector3 (h, 0, v);

			transform.Translate (v3.normalized * speed * Time.deltaTime);

		} else {
			anim.SetBool ("isWalking", false);
		}

		oldFire = fire;
	}
}
