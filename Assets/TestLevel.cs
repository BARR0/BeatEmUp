using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLevel : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		foreach (GameObject go in GameController.controllers.Keys) {
			GameObject tmp = Instantiate (go);
			PlayerController pm = tmp.GetComponent<PlayerController> ();
			//GameController.addPlayer (pm);
			pm.inputAxis = GameController.controllers[go];
		}
		// GameController.CreatePlayers();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
