using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonPlayer : MonoBehaviour
{
    float horizontal;
    float speed = 5f;
    private bool isFacingRight = false;
    float jump = 4f;
    private bool isJumping = false;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        FlipSprite();

        if (Input.GetButtonDown("Jump") && !isJumping);
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            isJumping = true;
        }
    }

    void FixedUpdte()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    void FlipSprite()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;
    }
}
