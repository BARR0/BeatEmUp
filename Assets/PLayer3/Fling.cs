using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fling : MonoBehaviour {
    public GameObject shuriken;

    private Transform spot;
	// Use this for initialization
	void Start () {
        spot = transform.GetChild(1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Flingable(){
        Instantiate(shuriken, spot.transform.position, transform.rotation);
    }
}
