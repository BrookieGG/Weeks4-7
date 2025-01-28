using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourHand : MonoBehaviour
{
    public AudioClip clip;
    public float hourhand = 0.01f;
    //public float hour;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rot = transform.eulerAngles;
        rot.z += hourhand;
        transform.eulerAngles = rot;

        if (rot.z == -30)
        {
            audioSource.PlayOneShot(clip);
        }
        if (rot.z == -60)
        {
            audioSource.PlayOneShot(clip);
        }

    }
}
