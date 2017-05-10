using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corpse : MonoBehaviour {

	public GameObject player;

	public void revive(){
		Instantiate (player, this.transform.position, player.transform.rotation);
		Destroy (this.gameObject);
	}
}
