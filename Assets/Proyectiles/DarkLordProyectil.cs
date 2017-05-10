using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkLordProyectil : MonoBehaviour {
	private Rigidbody rb;
    private Transform pivotPosition;
    private AudioSource source;

	public float force;
    public AudioClip sound;

	// Use this for initialization
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }
	void Start () {
        source.PlayOneShot(sound);
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
