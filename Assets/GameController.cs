using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public static GameController instance;
	public GameObject monster1;
	public Vector3 spawnValues;
	//Call for method of this class use in toher scripts
	//GameController.instante.method()

	void Awake () {
		if (instance == null) {
			instance = this;
		} else if (instance != null) {
			Destroy (gameObject);
		}
	}

	public void spawnMonsters() {
		
	}
}
