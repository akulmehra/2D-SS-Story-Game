using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class checkpoint : MonoBehaviour {

    public GameObject killCollider;
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        killCollider.GetComponent<killCollider>().lastCheckPoint = transform;
    }
}
