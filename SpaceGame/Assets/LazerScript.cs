﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerScript : MonoBehaviour
{
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        Rigidbody laser = GetComponent<Rigidbody>();
        laser.velocity = Vector3.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
