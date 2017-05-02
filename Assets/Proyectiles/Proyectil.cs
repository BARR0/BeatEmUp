using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour {
	private Rigidbody rb;
	public float force;
    public Proyectil instance { get; set; }

	// Use this for initialization
	void Start () {
        instance = this;
        Destroy(gameObject, 10);
	}

	// Update is called once per frame
	void Update () {
        transform.Translate(-5*Time.deltaTime*force,0,0);
	}

	void OnBecameInvisible() {
		Destroy (this.gameObject);
	}

    void OnTriggerEnter(Collider c)
    {
        if(c.gameObject.layer == 10)
        {
            Destroy(this.gameObject);
        }
    }
}
