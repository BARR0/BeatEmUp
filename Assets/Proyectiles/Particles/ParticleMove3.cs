using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMove3 : MonoBehaviour {
	public AudioClip sound;

	private AudioSource source;

	// Use this for initialization
	void Awake()
	{
		source = GetComponent<AudioSource>();
	}
	void Start () {
		source.PlayOneShot(sound);
		StartCoroutine (remove ());
	}

	// Update is called once per frame
	void Update () {
		//transform.Translate (-3f * Time.deltaTime, 0, 0, Space.Self);
	}

	void OnBecameInvisible() {
		Destroy (gameObject);
	}

	private IEnumerator remove() {

		yield return new WaitForSeconds (5);
		Destroy (gameObject);
	}
		
}
