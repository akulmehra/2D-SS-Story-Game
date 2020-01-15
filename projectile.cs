using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour {

    public float shootForce;

	// Use this for initialization
	void Start () {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(shootForce, 0));
	}
	
	// Update is called once per frame
	void Update () {

        Destroy(gameObject, 1.5f);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy") {
            Destroy(collision.gameObject);
        }
    }
}
