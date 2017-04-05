using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniBossController : MonoBehaviour {

	public float life;
	public GameObject minion;
	public Animator anim;
	public float defaultSpeed;
	public double attackDistance;

	private State current;
	private Symbol clode, far, low, time;
	private MonoBehaviour currentBehavior;
	private bool dead;

	// Use this for initialization
	void Start () {
		Symbol midclose = new Symbol ("midclose");
		Symbol close = new Symbol("close");
		Symbol far = new Symbol ("far");
		Symbol low = new Symbol ("low");
		Symbol time = new Symbol ("time");

		State walk = new State ("walk", typeof(StateWalk));
		State attack = new State ("attack", typeof(StateAttack));
		State spawn = new State ("spawn", typeof(StateSpawn));
		State wait = new State ("wait", typeof(StateWait));

		walk.AddNeighbor (close, attack);
		walk.AddNeighbor (low, spawn);

		attack.AddNeighbor (far, walk);
		attack.AddNeighbor (low, spawn);
		attack.AddNeighbor (time, spawn);
		attack.AddNeighbor (midclose, walk);

		spawn.AddNeighbor (close, attack);
		spawn.AddNeighbor (time, walk);

		wait.AddNeighbor (midclose, walk);
		wait.AddNeighbor (close, attack);
		wait.AddNeighbor (low, spawn);

		current = wait;

		currentBehavior = (MonoBehaviour)gameObject.AddComponent (current.Behavior);
		StartCoroutine (CheckSymbols());
	}

	IEnumerator CheckSymbols() {

		while (true) {
			
			State temp = null;

			if (life < 30) {
				temp = current.ApplySymbol (low);
			}

			if (temp != null && temp != current) {

				current = temp;
				Destroy (currentBehavior);
				currentBehavior = (MonoBehaviour)gameObject.AddComponent (current.Behavior);
			}

			yield return new WaitForSeconds (1);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}

	Transform FindCosest() {

		GameObject dummy = GameController.players [0].gameObject;
		float mindist = Vector3.Distance (this.gameObject.transform.position, dummy.transform.position);

		foreach (PlayerController go in GameController.players) {

			float distDummy = Vector3.Distance (this.gameObject.transform.position, go.gameObject.transform.position);
			//Iterates through players to find the shortest one
			if ( distDummy < mindist) {

				mindist = distDummy;
				dummy = go.gameObject;
			}

		}

		return dummy.transform;
	}
}
