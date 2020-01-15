using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killCollider : MonoBehaviour {

    public Transform lastCheckPoint;

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player") {
            collision.transform.position = lastCheckPoint.position;
        }
    }
}
