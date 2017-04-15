﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UILogic2 : MonoBehaviour {

	public int n;
	public GameObject[] prefabs;
	public Image[] draw;
	public Sprite[] selected;
	public Sprite[] unselected;

	private int[] p;
	//Save previous input of the joystick
	private float[] h, oldh;

	void Start() {
		p = new int[n];
		oldh = new float[n];
		h = new float[n];

		for(int i = 0; i < draw.Length; ++i){
			draw [i].overrideSprite = unselected [i % 4];
		}

		for(int i = 0; i < n; ++i){
			p [i] = n;
			oldh [i] = 0;
		}
	}

	void Update () {

		//Get controller axis
		h[0] = Input.GetAxis ("Horizontal");
		h[1] = Input.GetAxis ("Horizontal2");
		h[2] = Input.GetAxis ("Horizontal3");
		h[3] = Input.GetAxis ("Horizontal4");

		print (Mathf.Ceil( h [0] ));

		for(int i = 0; i < n; ++i){
			if (( Mathf.Ceil( h [i] ) == 1 ) && (oldh [i] <= 0) && (p[i] < n )) {
				draw [n * i + p [i]].overrideSprite = unselected [p [i]];
				p [i]++;
				if(p[i] < n) draw [n * i + p [i]].overrideSprite = selected [p [i]];
			} else if (( Mathf.Floor( h [i] ) == -1 ) && (oldh [i] >= 0) && (p[i] > 0)) {
				if(p[i] < n) draw [n * i + p [i]].overrideSprite = unselected [p [i]];
				p [i]--;
				draw [n * i + p [i]].overrideSprite = selected [p [i]];
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
