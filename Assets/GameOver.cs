using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (Reset());
	}
	
	IEnumerator Reset(){
		yield return new WaitForSeconds(10);
		GameController.gcReset ();
		SceneManager.LoadScene ("MainMenu");
	}
}
