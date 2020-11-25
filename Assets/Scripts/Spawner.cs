using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] objects;
    private Vector3 spawnPosition;
    public float spawnTime = 6f; 
    public float enemy1YSpawnPosition = 1f; 
    public float enemy2YSpawnPosition = 1f; 
    public float enemy3YSpawnPosition = 1f;

    void Start() 
    {
        // Starting in 2 seconds, a projectile will be launched every 0.3 seconds
        // InvokeRepeating("LaunchProjectile", 2, 0.3F);

        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.

        //(fn,startTime,repeat this code in sec)
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        spawnPosition.x=Random.Range (-100, 100);
        int instantiateObj = UnityEngine.Random.Range(0, objects.Length);
        // Debug.Log(instantiateObj);
        if(instantiateObj==1)
        {
            spawnPosition.y=transform.position.y+enemy1YSpawnPosition;
        }
        else if(instantiateObj==2)
        {
            spawnPosition.y=transform.position.y+enemy2YSpawnPosition;
        }
        else if(instantiateObj==3)
        {
            spawnPosition.y=transform.position.y+enemy3YSpawnPosition;
        }
        else
        {
            spawnPosition.y=transform.position.y;
        }
        spawnPosition.z=transform.position.z;
        Instantiate(objects[instantiateObj],spawnPosition, Quaternion.identity);
    }
}
