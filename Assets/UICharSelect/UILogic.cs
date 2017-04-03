using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UILogic : MonoBehaviour {

	//Get player prefabs
	public GameObject swordman, assassin, gunslinger, wizard;

	//Sprites applied when selected
	public Sprite selectedSword, selectedAssassin, selectedWizard, selectedGun;

	//Icons from character select screen
	public GameObject[] images;

	//Key used to map player gameobject
	private int p1, p2, p3, p4;

	//default sprites when icon is not selected
	private Sprite unselectedSword, unselectedAssassin, unselectedWizard, unselectedGun;

	//Counter of Images to get current position of the selection
	private int s1, s2, s3, s4;

	//Used to change sprites when selected
	private Dictionary<int, Sprite> iconUnselected;
	private Dictionary<int, Sprite> iconSelected;

	//Save previous input of the joystick
	int oldv1, oldv2, oldv3, oldv4;

	void Start() {
		s1 = 0;
		s2 = 4;
		s3 = 8;
		s4 = 12;

		unselectedSword = images [s1].GetComponent<Sprite> ();
		unselectedGun = images [s2].GetComponent<Sprite> ();
		unselectedAssassin = images [s3].GetComponent<Sprite> ();
		unselectedWizard = images [s4].GetComponent<Sprite> ();

		iconUnselected = new Dictionary<int,Sprite> ();
		iconSelected = new Dictionary<int,Sprite> ();

		// Add sprites to dictionary
		for (int i = 0; i < 16; i++) {

			iconUnselected.Add (i, unselectedSword);
			iconSelected.Add (i, selectedSword);
			i++;
			iconUnselected.Add (i, unselectedGun);
			iconSelected.Add (i, selectedGun);
			i++;
			iconUnselected.Add (i, unselectedAssassin);
			iconSelected.Add (i, selectedAssassin);
			i++;
			iconUnselected.Add (i, unselectedWizard);
			iconSelected.Add (i, selectedWizard);

		}

		p1 = 5;
		p2 = 5;
		p3 = 5;
		p4 = 5;

		//Initialize variables
		oldv1 = 0; 
		oldv2 = 0; 
		oldv3 = 0; 
		oldv4 = 0;

	}

	void Update () {

		//Get controller axis
		float h1 = Input.GetAxis ("Horizontal");
		float h2 = Input.GetAxis ("Horizontal2");
		float h3 = Input.GetAxis ("Horizontal3");
		float h4 = Input.GetAxis ("Horizontal4");

		int v1 = 0, v2 = 0, v3 = 0, v4 = 0;

		// if any value is 0, do nothing
		if (h1 > 0) v1 =  1;
		if (h1 < 0) v1 = -1;
		if (h2 > 0) v2 =  1;
		if (h2 < 0) v2 = -1;
		if (h3 > 0) v3 =  1;
		if (h3 < 0) v3 = -1;
		if (h4 > 0) v4 =  1;
		if (h4 < 0) v4 = -1;

		// Controller 1 selections
		s1 = selectPlayer (v1, oldv1, s1, 0);
		oldv1 = v1;
		p1 = s1;

		//Controller 2 selections
		s2 = selectPlayer (v2, oldv2, s2, 4);
		oldv2 = v2;
		p2 = s2 - 4;

		//Controller 3 selections
		s3 = selectPlayer (v3, oldv3, s3, 8);
		oldv3 = v3;
		p3 = s3 - 8;

		//Controller 4 selections
		s4 = selectPlayer (v4, oldv4, s4, 12);
		oldv4 = v4;
		p4 = s4 - 12;
	}

	int selectPlayer(int v, int oldv, int s, int i) {
		if (v == 1 && v != oldv) {

			images [s].GetComponent<Image> ().overrideSprite = iconUnselected[s];

			if (s == i + 3) 
				s = i;
			else
				s++;

			images [s].GetComponent<Image> ().overrideSprite = iconSelected[s];

		} else if (v == -1 && v != oldv) {

			images [s].GetComponent<Image> ().overrideSprite = iconUnselected[s];

			if (s == i)
				s = i + 3;
			else 
				s--;

			images [s].GetComponent<Image> ().overrideSprite = iconSelected[s];
		}
		return s;
	}

	public void StartGame() {

		string p = "";

        GameController.gcReset();

        GameController.controllers.Add (swordman, p);

		GameController.controllers.Add (gunslinger, p);

		GameController.controllers.Add (assassin, p);

		GameController.controllers.Add (wizard, p);

        SceneManager.LoadScene("testlevel");
	}
}
