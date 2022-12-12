using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    [SerializeField]
    private float attractorMass;
    [SerializeField]
    private float attractionDistance;

    private float distanceFromAttractor;
    private Rigidbody rb;
    
    const float G = 6.674f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate()
    {
        AttractedObject[] attractors = FindObjectsOfType<AttractedObject>();

        foreach(AttractedObject attractedObj in attractors)
        {
            if (attractedObj != this)
            {
                Attract(attractedObj);
            }
        }
    }
    
    private void Attract(AttractedObject objToAttract)
    {
        Rigidbody rbToAttract = objToAttract.rb;

        Vector3 direction = rb.position - rbToAttract.position;
        distanceFromAttractor = direction.magnitude;

        float forceMagnitude = G * (attractorMass * rbToAttract.mass) / distanceFromAttractor;
        Vector3 force = direction.normalized * forceMagnitude;

        if (distanceFromAttractor < attractionDistance)
        {
            rbToAttract.AddForce(force);    
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, attractionDistance);
        Gizmos.color = Color.green;
    }
}
