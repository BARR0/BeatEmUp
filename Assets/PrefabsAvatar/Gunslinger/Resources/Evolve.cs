using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evolve : MonoBehaviour {

	public Sprite newSprite;
	
	private PlayerController pc;

	// Use this for initialization
	void Start () {
		pc = transform.parent.gameObject.GetComponent<PlayerController> ();
	}

	// Update is called once per frame
	void Update () {
		
		if ( pc.Level > 6 ) {

			transform.Translate (0, -0.4f, 0);
			//GetComponent<Animator> ().runtimeAnimatorController = (RuntimeAnimatorController)newController;
			GetComponent<Animator> ().runtimeAnimatorController = Resources.Load ("RebelioSprite_0") as RuntimeAnimatorController;
			GetComponent<SpriteRenderer> ().sprite = newSprite;
			Destroy (GetComponent<Evolve> ());
		}
	}
}
