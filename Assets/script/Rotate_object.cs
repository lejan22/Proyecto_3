using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_object : MonoBehaviour
{
    public float speed = 50f;



    // Update is called once per frame
    void Update()
    {
        //Rotación constante que permite a nuestros seres rotar como tanto aman hacer
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}
