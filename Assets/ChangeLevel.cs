using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour {

	public string nextscene;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider c) {
		//print ("~~~~~~~~~~~~~~~~~~~~~~~~hi1");
		if (c.gameObject.layer == 8) {
			foreach(PlayerController pc in GameController.players){
				DontDestroyOnLoad (pc.gameObject);
			}
			//print ("~~~~~~~~~~~~~~~~~~~~~~~~hi2");
			SceneManager.LoadScene (nextscene);
		}
	}
}
