using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstacle;
    // Start is called before the first frame update
    private Vector3 spawnPos = new Vector3(25,0,0);
    void Start()
    {
        Instantiate(obstacle, spawnPos, obstacle.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
