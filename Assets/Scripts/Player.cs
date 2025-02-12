using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 5;
    private bool playing = false;
    public AudioClip clip;
    public AudioSource audioSource;
    public GameObject Won;
    private bool hasWon = false;


    // Start is called before the first frame update
    void Start()
    {
        
        playing = true;
        audioSource = GetComponent<AudioSource>();
        Won.SetActive(false);
        hasWon = false;
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
    if (hasWon && Input.GetKeyDown(KeyCode.Space))
    {
        Won.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        audioSource.Stop();
    }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Car"))
        {
            Debug.Log("Try Again!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (collision.CompareTag("Win"))
        {
            Debug.Log("Won");
            if (Won != null)
            {
                Won.SetActive(true);
            }
            else
            {
                audioSource.PlayOneShot(clip);
                hasWon = true;
                playing = false;
            }
          
            
          
         
    }
    }
}
