using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour {
    public GameObject stone;

    private Transform spot;
	// Use this for initialization
	void Start () {
        spot = transform.GetChild(2);
	}

    // Update is called once per frame
    void Update() {
       
	}

    void Throw(){
        Instantiate(stone, spot.transform.position, transform.rotation);
    }
}
