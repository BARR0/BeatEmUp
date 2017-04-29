using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLogic : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetAxis ("Fire1") != 0) {

			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
		}

	}

	public void Startgame() {

		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}
}
