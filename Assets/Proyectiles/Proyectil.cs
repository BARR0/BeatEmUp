using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour {
	private Rigidbody rb;
    private AudioSource source;

	public float force;
    public AudioClip sound;
    public AudioClip soundHit;

	// Use this for initialization
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }
	void Start () {
        if(sound != null)
        {
            source.PlayOneShot(sound);
        }
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
            if(soundHit != null)
            {
                source.PlayOneShot(soundHit);
            }
            Destroy(this.gameObject);
        }
    }
}
