using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 5;
    public GameObject Win;
    private bool playing = false;
    // Start is called before the first frame update
    void Start()
    {
        Win.SetActive(false);
        playing = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (playing == true)
        {
            Vector2 pos = transform.position;

            pos.y += Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
            transform.position = pos;
        }
        if (playing == false && Input.GetKeyDown(KeyCode.Space))
        {
            Win.SetActive(false);
            playing = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Car")
        {
            Debug.Log("Try Again!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
        if (collision.tag == "Win")
        {
            playing = false;
            Win.SetActive(true);
        }
    }
}
