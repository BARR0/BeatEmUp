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
        this.transform.LookAt(target.position);
	}
    IEnumerator FindClosestTarget()
    {

        while (true)
        {
            if (GameController.players.Count <= 0) break;
            PlayerController dummy = GameController.players[0];
            float mindist = dummy.life;

            foreach (PlayerController go in GameController.players)
            {

                float distDummy = go.life;

                //Iterates through players to find the shortest one
                if (distDummy < mindist)
                {

                    mindist = distDummy;
                    dummy = go;
                }

            }

            target = dummy.transform;

            yield return new WaitForSeconds(1);
        }
    }
}
