using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlMove : MonoBehaviour
{
    public float maxSpeed = 10f;
    public float jumpForce = 700f;
    public Rigidbody2D rb;
    public float move;
    public bool facingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(new Vector2(0f, jumpForce));
        }
        rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);
        if (move > 0 && !facingRight)
            flip();
        if (move < 0 && facingRight)
            flip();
    }
    public void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
