using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UILogic : MonoBehaviour {

	public GameObject swordman, assassin, gunslinger, wizard, events;
	private string p1, p2, p3, p4;

	void Start() {
		p1 = "4";
		p2 = "2";
		p3 = "3";
		p4 = "";

		GameController.gcReset ();
		GameController.controllers.Add (swordman, p1);
		GameController.controllers.Add (gunslinger, p2);
		GameController.controllers.Add (assassin, p3); 
		GameController.controllers.Add (wizard, p4);

		SceneManager.LoadScene("testlevel");
	}

	public void SelectChar1() {
		
	}

	public void SelectChar2() {

	}

	public void SelectChar3() {

	}

	public void SelectChar4() {

	}

	public void StartGame() {
		GameController.controllers.Add (swordman, p1);
		GameController.controllers.Add (gunslinger, p2);
		GameController.controllers.Add (assassin, p3); 
		GameController.controllers.Add (wizard, p4);

		GameController.gcReset ();

		SceneManager.LoadScene("developScene", LoadSceneMode.Additive);

	}
}
