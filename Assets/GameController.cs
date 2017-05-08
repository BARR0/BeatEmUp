using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static Dictionary<GameObject, string> controllers;

	public static List<PlayerController> players, dead;

	private static double exp;

	public static void gcReset() {
		if(GameController.players != null){
			foreach (PlayerController pc in GameController.players)
				Destroy (pc);
		}
		GameController.controllers = new Dictionary<GameObject, string>();
		GameController.players = new List<PlayerController> (FindObjectsOfType (typeof(PlayerController)) as PlayerController[]);
		GameController.dead = new List<PlayerController> ();
//		foreach (PlayerMove pm in players)
//			print (pm);
		GameController.exp = 0.0;
	}

	public static void addPlayer(PlayerController pm){
		if (!GameController.players.Contains (pm)) {
			GameController.players.Add (pm);
		}
	}
	public static void removePlayer(PlayerController pm){
		if (GameController.players.Contains (pm)) {
			GameController.players.Remove (pm);
			GameController.dead.Add (pm);
		}
	}

	public static void CreatePlayers(){
		foreach(GameObject go in controllers.Keys){
			print (go.name);
			GameObject clone = Instantiate(go);
			// clone.GetComponent<PlayerMove>().inputAxis = controllers[go];
		}
	}

	public static void ReviveAll(){
		foreach(PlayerController pc in dead){
			GameController.players.Add (pc);
			GameController.dead.Remove (pc);
			Instantiate (pc);
		}
	}

	public static void addExp(double moreexp){
		GameController.exp += moreexp;
		if (GameController.exp >= 1.0) {
			GameController.exp = 0.0;
			foreach (PlayerController pc in GameController.players) {
				pc.gainLevel ();
			}
		}
	}
}
