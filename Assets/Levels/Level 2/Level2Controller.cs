using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    }
}
