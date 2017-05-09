using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UILogic2 : MonoBehaviour {

	public int n;
	public GameObject[] prefabs;
	// public Image[] draw;
	public Animator[] anim;
	public Text[] offText;
	// public Sprite[] selected;
	// public Sprite[] unselected;

	private int[] p;
	//Save previous input of the joystick
	private float[] h, oldh, start, oldstart;

	void Start() {
		p = new int[n];
		oldh = new float[n];
		h = new float[n];
		start = new float[n];
		oldstart = new float[n];

		// for(int i = 0; i < draw.Length; ++i){
			// draw [i].overrideSprite = unselected [i % 4];
			// anim [i] = draw [i].GetComponent<Animator> ();
			// anim [i].SetBool ("selected", false);
		// }
		for(int i = 0; i < n; ++i){
			p [i] = n;
			oldh [i] = 0;
			start [i] = 0;
		}
	}

	void Update () {
		start[0] = Input.GetAxis ("Fire1");
		start[1] = Input.GetAxis ("Fire12");
		start[2] = Input.GetAxis ("Fire13");
		start[3] = Input.GetAxis ("Fire14");

		for(int i = 0; i < start.Length; ++i){
			if(start[i] == 1 && oldstart[i] == 0)
				StartGame();
			oldstart [i] = start [i];
		}

		//Get controller axis
		h[0] = Input.GetAxis ("Horizontal");
		h[1] = Input.GetAxis ("Horizontal2");
		h[2] = Input.GetAxis ("Horizontal3");
		h[3] = Input.GetAxis ("Horizontal4");

		//print (h[0] + h[1] + h[2] + h[3]);

		for(int i = 0; i < n; ++i){
			if (( Mathf.Ceil( h [i] ) == 1 ) && (oldh [i] <= 0) && (p[i] < n )) {
				// draw [n * i + p [i]].overrideSprite = unselected [p [i]];
				anim [n * i + p[i]].SetBool ("selected", false);
				p [i]++;
				// if(p[i] < n) draw [n * i + p [i]].overrideSprite = selected [p [i]];
				if (p [i] < n)
					anim [n * i + p [i]].SetBool ("selected", true);
				else
					offText [i].text = "Off";
			} else if (( Mathf.Floor( h [i] ) == -1 ) && (oldh [i] >= 0) && (p[i] > 0)) {
				// if(p[i] < n) draw [n * i + p [i]].overrideSprite = unselected [p [i]];
				if (p [i] < n)
					anim [n * i + p [i]].SetBool ("selected", false);
				else
					offText [i].text = "";
				p [i]--;
				// draw [n * i + p [i]].overrideSprite = selected [p [i]];
				anim [n * i + p [i]].SetBool("selected", true);
			}
			oldh [i] = h [i];
		}
	}

	public void StartGame() {
		GameController.gcReset();

		for(int i = 0; i < n; ++i){
			if (p [i] == n)
				//print ("a");
				continue;
			if (GameController.controllers.ContainsKey (prefabs [p [i]]))
				//print ("b");
				return;
			if (p [i] < n)
				//print ("c");
				GameController.controllers.Add (prefabs [p [i]], i == 0 ? "" : (i + 1).ToString ());
		}

		if (GameController.controllers.Count > 0) SceneManager.LoadScene("Level1Scene");
	}
}
