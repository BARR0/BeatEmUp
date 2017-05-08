using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Evolve : MonoBehaviour {

	public Sprite newSprite;
	public float offset;
	public RuntimeAnimatorController rac;

	private PlayerController pc;

	// Use this for initialization
	void Start () {
		pc = transform.parent.gameObject.GetComponent<PlayerController> ();
	}

	// Update is called once per frame
	void Update () {
		
		if ( pc.Level > 6 ) {

			transform.Translate (0, offset, 0);
			//GetComponent<Animator> ().runtimeAnimatorController = (RuntimeAnimatorController)newController;

			//GetComponent<Animator> ().runtimeAnimatorController = Resources.Load (path_Controller) as RuntimeAnimatorController;

			GetComponent<Animator> ().runtimeAnimatorController = rac as RuntimeAnimatorController;

			GetComponent<SpriteRenderer> ().sprite = newSprite;
			Destroy (GetComponent<Evolve> ());
		}
	}
}
