using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invocable : MonoBehaviour {
    public GameObject invocable;
    Transform pivot;
    // Use this for initialization
    void Start()
    {
        pivot = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Invoke()
    {
        Instantiate(invocable, pivot.transform.position, pivot.transform.rotation);
    }
}
