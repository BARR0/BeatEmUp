using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMove1 : MonoBehaviour {
    public AudioClip sound;

    private AudioSource source;

	// Use this for initialization
    void Awake()
    {
        source = source = GetComponent<AudioSource>();
    }
	void Start () {
        source.PlayOneShot(sound);
	}

	// Update is called once per frame
	void Update () {
		transform.Translate (-3f * Time.deltaTime, 0, 0, Space.Self);
	}

	void OnBecameInvisible() {
		Destroy (gameObject);
	}

    void OnTriggerEnter(Collider c)
    {
        if(c.gameObject.layer == 10)
        {
            Destroy(this.gameObject);
        }
    }
}
