using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    private AnimationCurve curve;
    [SerializeField]
    private float attractorMass;
    [SerializeField]
    private float attractionDistance;

    private float distanceFromAttractor;
    private float curveModifier;
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

        //curveModifier = curve.Evaluate(distanceFromAttractor / attractionDistance);
        float forceMagnitude = G * (attractorMass * rbToAttract.mass) / distanceFromAttractor;
        
        Vector3 force = direction.normalized * forceMagnitude;

        if (distanceFromAttractor < attractionDistance)
        {
            rbToAttract.AddForce(force);    
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attractionDistance);
    }
}
