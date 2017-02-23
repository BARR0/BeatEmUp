using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour {
	private Rigidbody rb;
	public float force;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
        transform.Translate(-5*Time.deltaTime,0,0);
	}

	void OnBecameInvisible() {
		Destroy (gameObject);
	}
}
