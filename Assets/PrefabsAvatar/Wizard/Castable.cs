using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castable : MonoBehaviour {
	public GameObject magic;
    public GameObject magic2;

	private Transform spot;
	private PlayerController par;
	private bool flag;

	// Use this for initialization
	void Start () {
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
	}

	IEnumerator heal(){
		while (true) {
			par.life++;
			yield return new WaitForSeconds(1f);
		}
	}
}
