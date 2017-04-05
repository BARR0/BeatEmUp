using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delimiter : MonoBehaviour {

	public float max;

	private GameObject wallb, wallf;

	// Use this for initialization
	void Start () {
		Vector3 f = new Vector3 (transform.position.x + max/2f, transform.position.y, transform.position.z),
		        b = new Vector3 (transform.position.x - max/2f, transform.position.y, transform.position.z);
		this.transform.GetChild (0).position = f;
		this.transform.GetChild (1).position = b;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameController.players.Count <= 0)
			return;
		float maxx = GameController.players[0].transform.position.x, minx = GameController.players[0].transform.position.x;
		foreach(PlayerController pm in GameController.players){
			minx = pm.transform.position.x < minx ? pm.transform.position.x : minx;
			maxx = pm.transform.position.x > maxx ? pm.transform.position.x : maxx;
		}
		this.transform.position = new Vector3 ((maxx + minx)/2f, this.transform.position.y, this.transform.position.z);
	}
}
