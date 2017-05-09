using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Evolve : MonoBehaviour {

	public Sprite newSprite;
	public float offsety;
	public float offsetx;
	public RuntimeAnimatorController rac;

	private PlayerController pc;

	// Use this for initialization
	void Start () {
		pc = transform.parent.gameObject.GetComponent<PlayerController> ();
	}

	// Update is called once per frame
	void Update () {
		
		if ( pc.Level > 6 /*|| true*/) {

			pc.dmg1 = pc.new_dmg1;
			pc.dmg2 = pc.new_dmg2;
			pc.dmg3 = pc.new_dmg3;
			transform.Translate (offsetx, offsety, 0);
			//GetComponent<Animator> ().runtimeAnimatorController = (RuntimeAnimatorController)newController;

			//GetComponent<Animator> ().runtimeAnimatorController = Resources.Load (path_Controller) as RuntimeAnimatorController;

			GetComponent<Animator> ().runtimeAnimatorController = rac as RuntimeAnimatorController;

			GetComponent<SpriteRenderer> ().sprite = newSprite;
			Destroy (GetComponent<Evolve> ());
		}
	}
}
