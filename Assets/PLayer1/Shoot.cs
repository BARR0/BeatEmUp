using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    public GameObject bullet;

    private Transform spot;
    private Transform spot2;
	// Use this for initialization
	void Start () {
        spot = transform.GetChild(0);
        spot2 = transform.GetChild(1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void shootable()
    {
        Instantiate(bullet, spot.transform.position, transform.rotation);
        Instantiate(bullet, spot2.transform.position, spot2.transform.rotation);
    }

}
