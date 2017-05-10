using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimer : MonoBehaviour {
    private Transform target;
    // Use this for initialization
    void Start () {
        target = GameController.players[0].gameObject.transform;
        StartCoroutine(FindClosestTarget());
    }
	
	// Update is called once per frame
	void Update () {
        if (GameController.players.Count > 0)
        {
            this.transform.LookAt(target.position);
        }
        
	}
    IEnumerator FindClosestTarget()
    {

        while (true)
        {
            if (GameController.players.Count <= 0) break;
            PlayerController dummy = GameController.players[0];
            //float mindist = dummy.life;

            int number = Random.Range(0,GameController.players.Count);

            target = GameController.players[number].transform;

            yield return new WaitForSeconds(1);
        }
    }
}
