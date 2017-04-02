using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public static Dictionary<GameObject, string> controllers;

	private static List<PlayerMove> players;

	public static void gcReset() {
		GameController.controllers = new Dictionary<GameObject, string>();
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

	public static void CreatePlayers(){
		foreach(GameObject go in controllers.Keys){
			GameObject clone = Instantiate(go);
			// clone.GetComponent<PlayerMove>().inputAxis = controllers[go];
		}
	}
}
