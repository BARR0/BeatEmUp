using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMove : MonoBehaviour {
    public AudioClip sound;

    private AudioSource source;
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

	// Use this for initialization
	void Start () {
        source.PlayOneShot(sound);
	}

	// Update is called once per frame
	void Update () {
		transform.Translate (-1.5f * Time.deltaTime, 0, 0, Space.Self);
	}

	void OnBecameInvisible() {
		Destroy (gameObject);
	}
}
