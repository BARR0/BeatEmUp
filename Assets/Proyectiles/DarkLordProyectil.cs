using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkLordProyectil : MonoBehaviour {
	private Rigidbody rb;
    private Transform pivotPosition;
	public float force;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 10);
	}

	// Update is called once per frame
	void Update () {
        transform.Translate(0,0, 5 * Time.deltaTime * force);
	}

	void OnBecameInvisible() {
		Destroy (this.gameObject);
	}
}
