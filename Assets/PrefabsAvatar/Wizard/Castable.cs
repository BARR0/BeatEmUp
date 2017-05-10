using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castable : MonoBehaviour {
	public GameObject magic;
    public GameObject magic2;
	public GameObject magic3;

	private Transform spot;
	private PlayerController par;
	private bool flag;
	private int maxHeal;
	private int currentHeals;

	// Use this for initialization
	void Start () {
		maxHeal = 3;
		currentHeals = 0;
		spot = transform.GetChild(0);
		par = this.transform.parent.GetComponent<PlayerController> ();
		flag = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void CastFire() {
		Instantiate(magic, spot.transform.position, transform.rotation);
	}

    void CastWildFire()
    {
        Instantiate(magic2, spot.transform.position, transform.rotation);
    }

	void healPassive(){
		if (flag) {
			StartCoroutine (heal ());
			flag = false;
		}

		if (currentHeals < maxHeal) {
			currentHeals++;
			Instantiate(magic3, spot.transform.position, transform.rotation);
			StartCoroutine (healings ());
		}
	}

	IEnumerator heal(){
		while (true) {
			par.life++;
			yield return new WaitForSeconds(4f);
		}
	}

	IEnumerator healings() {
		yield return new WaitForSeconds (5.5f);
		currentHeals--;
	}
}
