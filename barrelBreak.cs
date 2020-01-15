using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrelBreak : MonoBehaviour {

    Rigidbody2D rb;
    public GameObject breakEffect;
    // Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(rb.velocity.x);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(rb.velocity.x > 1.5) {
            Instantiate(breakEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
