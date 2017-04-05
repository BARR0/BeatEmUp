using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinnable : MonoBehaviour {
    public GameObject spinnable;
    Transform pivot;
	// Use this for initialization
	void Start () {
        pivot = transform.GetChild(0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Spin()
    {
        Instantiate(spinnable, pivot.transform.position, pivot.transform.rotation);
    }
}
