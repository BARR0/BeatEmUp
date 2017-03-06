using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetArena : MonoBehaviour {
	public GameObject arenaWall;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider c) {


		if (c.gameObject.layer == 8) {
			Vector3 arenaPos1 = new Vector3 (this.transform.position.x - 2.5f, this.transform.position.y, this.transform.position.z);
			Vector3 arenaPos2 = new Vector3 (this.transform.position.x + 2.5f, this.transform.position.y, this.transform.position.z);
			Instantiate ( arenaWall, arenaPos1, arenaWall.transform.rotation );
			Instantiate ( arenaWall, arenaPos2, arenaWall.transform.rotation );
			Destroy (this.gameObject);
		}

	}
}
