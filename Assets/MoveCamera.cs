using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

	public Camera cam;
	public Vector3 initPos;
	public float minSize;
	public Transform p1,
	                 p2,
	                 p3,
	                 p4;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float maxx = Mathf.Max (p1.position.x, p2.position.x, p3.position.x, p4.position.x),
		      minx = Mathf.Min (p1.position.x, p2.position.x, p3.position.x, p4.position.x);

		this.transform.position = new Vector3 (minx + (maxx - minx)/2.0f, this.transform.position.y, this.transform.position.z);
		cam.orthographicSize = Mathf.Max((maxx - minx)/2.5f, minSize);
	}
}
