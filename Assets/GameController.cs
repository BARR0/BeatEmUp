using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	private static GameController instance;
	private static List<PlayerMove> players;

	void Awake () {
		if (instance == null) {
			instance = this;
		} else {
			Destroy (gameObject);
		}
		players = new List<PlayerMove> (FindObjectsOfType (typeof(PlayerMove)) as PlayerMove[]);
//		foreach (PlayerMove pm in players)
//			print (pm);
	}

	public static void addPlayer(PlayerMove pm){
		if (!GameController.players.Contains (pm)) {
			GameController.players.Add (pm);
		}
	}
	public static void removePlayer(PlayerMove pm){
		if (GameController.players.Contains (pm)) {
			GameController.players.Remove (pm);
		}
	}
}
