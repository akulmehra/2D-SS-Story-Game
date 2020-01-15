using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour {


    public float distanceFromPlayer;
    public GameObject player;
    public bool active;
    Animator anim;
    // Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        active = false;
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Vector2.Distance(gameObject.transform.position, player.transform.position) < distanceFromPlayer) {
            active = true;
            anim.SetBool("active", true);
        }

        if(active==true) {
            transform.position = Vector2.MoveTowards(gameObject.transform.position, player.transform.position, 3 * Time.deltaTime);
        }
	}
}
