using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public float spawnTime = 8f;
    //private float nextSpawn = 3f;
    private float CountDown = 1f;
    public GameObject car;
    public Transform[] spawnPoints;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (CountDown <= 0)
        {
            SpawnCar();
            CountDown = 1f;
        } else
            {   
                CountDown -= Time.deltaTime;
            }
        
        void SpawnCar()
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[randomIndex];
            
            Instantiate(car, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
