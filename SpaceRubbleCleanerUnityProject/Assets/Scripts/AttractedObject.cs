using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractedObject : MonoBehaviour
{
    [HideInInspector] 
    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
}
