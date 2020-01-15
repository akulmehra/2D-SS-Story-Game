using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveObject : MonoBehaviour {

    GameObject box;
    public float distance;
    public LayerMask boxMask;
    public Animator anim;
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, boxMask);

        if(hit.collider != null && Input.GetKeyDown(KeyCode.E)) {
            box = hit.collider.gameObject;

            if(box.GetComponent<FixedJoint2D>().enabled) {
                box.GetComponent<FixedJoint2D>().enabled = false;
                anim.SetBool("pushing", false);
            } else {
                box.GetComponent<FixedJoint2D>().enabled = true;
                anim.SetBool("pushing", true);
            }
            box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
        }
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
    }
}
