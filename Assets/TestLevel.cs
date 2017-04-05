using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLevel : MonoBehaviour {
    public Vector3[] spawn;
	// Use this for initialization
	void Awake () {
        int counter = 0;
		foreach (GameObject go in GameController.controllers.Keys) {
			GameObject tmp = Instantiate (go,spawn[counter++],go.transform.rotation);
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
