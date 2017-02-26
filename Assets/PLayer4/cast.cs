using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cast : MonoBehaviour {
	public GameObject magic;

	private Transform spot;

	// Use this for initialization
	void Start () {
		spot = transform.GetChild(0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void casting() {
		Instantiate(magic, spot.transform.position, transform.rotation);
	}
}
