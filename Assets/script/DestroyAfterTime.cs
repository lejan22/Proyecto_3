using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    //Tiemponecesario para el caput
    [SerializeField] private float lifeTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        //El caput sucede
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
