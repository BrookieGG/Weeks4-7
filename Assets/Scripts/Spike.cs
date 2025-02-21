using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spike : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //resart game
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
