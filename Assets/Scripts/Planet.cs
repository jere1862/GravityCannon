﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class Planet : MonoBehaviour
{
    public float gravity;
    public float maxGravity;

    // Start is called before the first frame update
    void Start()
    {

        gravity = transform.localScale.y * 10; //(float) System.Math.Tanh(transform.localScale.y) * 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
