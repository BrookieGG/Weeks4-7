using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Zombie : MonoBehaviour
{
    public Transform player;
    float speed = 1;
    float jump = 1;
    public LayerMask ground;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool shouldJump;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
 
        //is on ground
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1, ground);

        //player direction
        float direction = Mathf.Sign(player.position.x - transform.position.x);

        bool isPlayerAbove = Physics2D.Raycast(transform.position, Vector2.up, 3, 1 << player.gameObject.layer);

        if (isGrounded)
        {
            //chase player
            rb.velocity = new Vector2(direction * speed, rb.velocity.y);

            //jump

            //if there is ground
            RaycastHit2D groundInFront = Physics2D.Raycast(transform.position, new Vector2(direction, 0), 2, ground);

            //if gap
            RaycastHit2D gap = Physics2D.Raycast(transform.position + new Vector3(direction, 0, 0), Vector2.down, 2, ground); 

            //if platform
            RaycastHit2D platform = Physics2D.Raycast(transform.position, Vector2.up, 3, ground);

            if (!groundInFront.collider && !gap.collider)
            {
                shouldJump = true;
            }
            else if (isPlayerAbove && platform.collider)
            {
                shouldJump = true;
            }
        }
        
    }
    void FixedUpdate()
    {
        if (isGrounded && shouldJump)
        {
            shouldJump = false;
            Vector2 newdirection = (player.position - transform.position).normalized;

            Vector2 jumpDirection = newdirection * jump;

            rb.AddForce(new Vector2(jumpDirection.x, jump), ForceMode2D.Impulse);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //resart game
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
