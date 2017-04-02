using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static Dictionary<GameObject, string> controllers;

	public static List<PlayerController> players;

	public static void gcReset() {
		GameController.controllers = new Dictionary<GameObject, string>();
		players = new List<PlayerController> (FindObjectsOfType (typeof(PlayerController)) as PlayerController[]);
//		foreach (PlayerMove pm in players)
//			print (pm);
	}

	public static void addPlayer(PlayerController pm){
		if (!GameController.players.Contains (pm)) {
			GameController.players.Add (pm);
		}
	}
	public static void removePlayer(PlayerController pm){
		if (GameController.players.Contains (pm)) {
			GameController.players.Remove (pm);
		}
	}

	public static void CreatePlayers(){
		foreach(GameObject go in controllers.Keys){
			print (go.name);
			GameObject clone = Instantiate(go);
			// clone.GetComponent<PlayerMove>().inputAxis = controllers[go];
		}
	}
}
