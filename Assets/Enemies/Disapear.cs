using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disapear : MonoBehaviour {

	private SpriteRenderer sr;
	private bool invincible;

	// Use this for initialization
	void Start () {
		invincible = false;
		sr = this.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void disappear() {
		
		if (sr != null && !invincible) {
			sr.enabled = false;	
			invincible = true;
		}
	}
}
