using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flingable : MonoBehaviour {
    public GameObject shuriken;

    private Transform spot;
	// Use this for initialization
	void Start () {
        spot = transform.GetChild(1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Fling(){
        Instantiate(shuriken, spot.transform.position, spot.transform.rotation);
    }
}
