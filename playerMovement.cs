using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    public GameObject firePoint;
    public GameObject bullet;

    public float moveSpeed;
    public float jumpForce;
    public float ladderDistance;

    Rigidbody2D rb;
    Animator anim;
    public LayerMask ladderMask;

    private bool isGrounded;
    private bool isClimbing;
    private bool isMoving;

    public AudioSource audioSource;

    // Use this for initialization
    void Start () {

        anim = GetComponent<Animator>();
        isGrounded = true;
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        float horizontal = Input.GetAxis("Horizontal") * moveSpeed;
        //transform.Translate(new Vector3(horizontal, 0, 0));

        rb.velocity = new Vector2(horizontal, rb.velocity.y);

        if(horizontal != 0) {
            isMoving = true;
        } else {
            isMoving = false;
        }

        if(isMoving && isGrounded) {
            if (!audioSource.isPlaying)
                audioSource.Play();
        } else {
            audioSource.Stop();
        }

        if (isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }

        if(rb.velocity.y != 0f) {
            isGrounded = false;
            anim.SetBool("jump", true);
        } else {
            isGrounded = true;
            anim.SetBool("jump", false);
        }

        if(horizontal != 0) {
            anim.SetBool("walk", true);
        } else {
            anim.SetBool("walk", false);
        }

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, ladderDistance, ladderMask);

        if(hitInfo.collider != null) {
            if(Input.GetAxis("Vertical") > 0) {
                isClimbing = true;
                anim.SetBool("climb", true);
            }
        } else {
            isClimbing = false;
            anim.SetBool("climb", false);
        }

        if(isClimbing == true) {
            Climb();
        } else {
            rb.gravityScale = 1;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(bullet, firePoint.transform);
        }
    }

    void Jump() {
        rb.AddForce(new Vector2(0, jumpForce));
    }

    void Climb() {
        float vertical = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(Vector2.up * vertical);
        rb.gravityScale = 0;
    }

    void Shoot() {
        Instantiate(bullet, firePoint.transform);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "kill_collider") {
            Destroy(gameObject);
        }
    }
}
