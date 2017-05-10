using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Controller : MonoBehaviour
{
    public Vector3[] spawn;

	public AudioClip[] clips;
	private AudioSource backgroundmusic;

    // Use this for initialization
    void Awake()
    {
		GameController.ReviveDead ();
        int counter = 0;
		foreach (PlayerController pc in GameController.players) {
			pc.transform.position = spawn [counter++];
		}
        backgroundmusic = GetComponent<AudioSource>();
    }

	void Start()
	{
		
		backgroundmusic.clip = clips [0];
		backgroundmusic.Play();
	}

    // Update is called once per frame
	void Update()
	{
		if (GameController.players.Count <= 0) {
			StartCoroutine (end ());
		}
	}
	IEnumerator end(){
		yield return new WaitForSeconds (5f);
		SceneManager.LoadScene ("Game Over");
	}

	public void BossEncounter() 
	{
		backgroundmusic.clip = clips [1];
		backgroundmusic.Play();
	}
}
