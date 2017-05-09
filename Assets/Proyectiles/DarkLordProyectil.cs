using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkLordProyectil : MonoBehaviour {
	private Rigidbody rb;
	public float force;

	// Use this for initialization
	void Start () {
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
        if(c.gameObject.layer == 8)
        {
            PlayerController pc = c.GetComponent<PlayerController>();
            pc.life -= 10;
        }
    }
}
