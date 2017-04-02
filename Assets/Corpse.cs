using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corpse : MonoBehaviour {

	public GameObject player;
	public Animator anim;
	public Transform sprite;
	public string inputAxis;
	public int life;

	public void revive(){
		Instantiate (player, this.transform.position, player.transform.rotation);
	}
}
