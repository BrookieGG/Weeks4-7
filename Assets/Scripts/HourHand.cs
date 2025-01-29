using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourHand : MonoBehaviour
{
    public AudioClip clip;
    public float hourhand = 0.01f;
    public AudioSource audioSource;
    float z;
    public GameObject prefab;
    public GameObject spawner;
    private float lastSpawned = 0f;
    private float t;
    // Start is called before the first frame update
    void Start()
    {
        lastSpawned = t;
    }

    // Update is called once per frame
    void Update()
    {
       // Vector3 spawnerPosition = spawner.transform.position;
        t += Time.deltaTime;
        Vector3 rot = transform.eulerAngles;
        rot.z += hourhand;
        transform.eulerAngles = rot;
        z = rot.z % 360;


        if (Mathf.Abs(z % 30) < 0.1f && t - lastSpawned > 1f)
        {
            audioSource.PlayOneShot(clip);
            lastSpawned = t;
            GameObject spawned = Instantiate(prefab, spawner.transform.position, Quaternion.identity);
            Destroy(spawned, 0.5f);

        }
    }
}