using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour {
	private Rigidbody rb;
	public float force;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {
		rb.AddRelativeForce (-force, 0, 0, ForceMode.Acceleration);
	}

	void OnBecameInvisible() {
		Destroy (gameObject);
	}
}
