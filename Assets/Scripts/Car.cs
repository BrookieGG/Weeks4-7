using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public Rigidbody2D rigidb;
    public float minspeed = 8f;
    public float maxspeed = 22f;
    private float speed = 1f;
    private void Start()
    {
        speed = Random.Range(minspeed, maxspeed);
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 move = new Vector2(transform.right.x, transform.right.y);
        rigidb.MovePosition(rigidb.position + move * Time.deltaTime * speed);
    }
}
