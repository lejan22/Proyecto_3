using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstacle;
    
    private Vector3 spawnPos = new Vector3(25,0,0);
    public float startDelay = 1f;
    public float repeatRate = 2f;
    private PlayerController playerControllerScript;
    void Start()
    {
        InvokeRepeating("SpawnObject", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        //Forma mas simple de encontrar componente
        //layerControllerScript = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SpawnObject()
    {
        if (!playerControllerScript.gameOver)
        {
            Instantiate(obstacle, spawnPos, obstacle.transform.rotation);
        }
        
    }
}
