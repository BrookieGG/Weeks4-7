using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DungeonPlayer : MonoBehaviour
{
    float horizontal;
    float speed = 5f;
    private bool isFacingRight = false;
    float jump = 5f;
    private bool isJumping = false;
    private int coinCounter = 0;
    public TMP_Text counter;
    public GameObject coin;

    Rigidbody2D rb; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2 (horizontal * speed, rb.velocity.y);

        FlipSprite();

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            isJumping = true;
        }
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
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            collision.gameObject.SetActive(false);
            coinCounter += 1;
            counter.text = "Coins: " + coinCounter;
        }
        
    }
}
