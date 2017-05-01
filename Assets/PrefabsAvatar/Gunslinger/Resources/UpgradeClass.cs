using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeClass : MonoBehaviour {

	public GameObject newClass;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.A)) {
			Destroy (this.gameObject.transform.GetChild (0).gameObject);
			Instantiate (newClass, this.gameObject.transform);

		}
	}
}
