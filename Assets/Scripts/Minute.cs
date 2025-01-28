using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minute : MonoBehaviour
{
    public float hourhand = 0.01f;
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
    }
}
