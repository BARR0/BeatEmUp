using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static Dictionary<GameObject, string> controllers;

	public static List<PlayerController> players, dead;

	public static Dictionary<string, int> damage;

	private static double exp;

	public static void gcReset() {
		if(GameController.players != null){
			foreach (PlayerController pc in GameController.players)
				Destroy (pc);
		}
		GameController.controllers = new Dictionary<GameObject, string>();
		GameController.players = new List<PlayerController> (FindObjectsOfType (typeof(PlayerController)) as PlayerController[]);
		GameController.dead = new List<PlayerController> ();
		GameController.damage = new Dictionary<string, int> ();
//		foreach (PlayerMove pm in players)
//			print (pm);
		GameController.exp = 0.0;
		GameController.damage.Add ("assassin", 0);
		GameController.damage.Add ("wizard", 0);
		GameController.damage.Add ("knight", 0);
		GameController.damage.Add ("gunslinger", 0);
		GameController.damage.Add ("heal", 1);
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

	public static void ChangeDamage(string player, int damage) {
		GameController.damage [player] = damage;

	}

	public static int ApplyDamage(string player){
		return GameController.damage [player];
	}
}
