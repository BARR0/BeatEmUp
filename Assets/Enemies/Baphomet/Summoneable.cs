using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summoneable : MonoBehaviour {
    public GameObject minion;

    private Transform pivot;
	// Use this for initialization
	void Start () {
        pivot = transform.GetChild(0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Summon()
    {
        Instantiate(minion, pivot.transform.position, transform.rotation);
    }
}
