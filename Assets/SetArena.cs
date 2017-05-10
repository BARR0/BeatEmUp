using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetArena : MonoBehaviour {
	
	public GameObject arenaWall;
	public GameObject[] enemys;
	public Vector3[] spawnPoint;

	private GameObject wall1, wall2;
	private bool isActive;
	public int enemysToKill;

	private Vector3 start1, start2;
	private float arenaPos1, arenaPos2;

	// Use this for initialization
	void Start () {
		arenaPos1 = this.transform.position.x - 2.5f;
		arenaPos2 = this.transform.position.x + 2.5f;
		start1 = new Vector3 (this.transform.position.x - 25.5f, this.transform.position.y, this.transform.position.z);
		start2 = new Vector3 (this.transform.position.x + 25.5f, this.transform.position.y, this.transform.position.z);
		isActive = false;
		wall1 = null;
		wall2 = null;
		//enemysToKill = 5;

	}

	// Update is called once per frame
	void Update () {

		if(start1.x < arenaPos1){
			start1.x += 1f;
			wall1.transform.Translate(new Vector3(1f, 0, 0));
		}

		if(start2.x > arenaPos2){
			start1.x -= 1f;
			wall2.transform.Translate(new Vector3(-1f, 0, 0));
		}

		if (enemysToKill < 1) {

			Destroy (wall1);
			Destroy (wall2);
			Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter(Collider c) {


		if (c.gameObject.layer == 8 && !isActive) {
			
			isActive = !isActive;
			// Vector3 arenaPos1 = new Vector3 (this.transform.position.x - 2.5f, this.transform.position.y, this.transform.position.z);
			// Vector3 arenaPos2 = new Vector3 (this.transform.position.x + 2.5f, this.transform.position.y, this.transform.position.z);
			wall1 = Instantiate ( arenaWall, start1, arenaWall.transform.rotation );
			wall2 = Instantiate ( arenaWall, start2, arenaWall.transform.rotation );


			spawnPoint [0] = new Vector3 (this.transform.position.x - 3.0f, this.transform.position.y, this.transform.position.z + 2.5f);
			spawnPoint [1] = new Vector3 (this.transform.position.x - 3.0f, this.transform.position.y, this.transform.position.z );
			spawnPoint [2] = new Vector3 (this.transform.position.x - 3.0f, this.transform.position.y, this.transform.position.z - 2.5f);

			spawnPoint [3] = new Vector3 (this.transform.position.x + 3.0f, this.transform.position.y, this.transform.position.z + 2.5f);
			spawnPoint [4] = new Vector3 (this.transform.position.x + 3.0f, this.transform.position.y, this.transform.position.z);
			spawnPoint [5] = new Vector3 (this.transform.position.x + 3.0f, this.transform.position.y, this.transform.position.z - 2.5f);


			StartCoroutine (SpawnEnemy());

			//this.transform.position.x - 3.0f, this.transform.position.y, this.transform.position.z + 2.0f
			//this.transform.position.x - 3.0f, this.transform.position.y, this.transform.position.z
			//this.transform.position.x - 3.0f, this.transform.position.y, this.transform.position.z - 2.0f

			//this.transform.position.x + 3.0f, this.transform.position.y, this.transform.position.z + 2.0f
			//this.transform.position.x + 3.0f, this.transform.position.y, this.transform.position.z
			//this.transform.position.x + 3.0f, this.transform.position.y, this.transform.position.z - 2.0f
		}
	}

	IEnumerator SpawnEnemy() {

		while (true) {
			int n = Random.Range (0, enemys.Length);

			Instantiate (enemys [n], spawnPoint [Random.Range (0, spawnPoint.Length)], enemys [n].transform.rotation);

			enemysToKill--;
			yield return new WaitForSeconds (1);
		}
	}
}
