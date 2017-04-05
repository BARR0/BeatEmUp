using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Controller : MonoBehaviour
{
    public Vector3[] spawn;
    // Use this for initialization
    void Awake()
    {
        int counter = 0;
		foreach (PlayerController pc in GameController.players) {
			pc.transform.position = spawn [counter++];
		}
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
}
