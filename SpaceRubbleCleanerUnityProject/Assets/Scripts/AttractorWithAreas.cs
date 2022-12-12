using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractorWithAreas : MonoBehaviour
{
    [SerializeField]
    private float attractorAreaOneForce;
    [SerializeField]
    private float attractorAreaTwoForce;
    [SerializeField]
    private float attractorAreaThreeForce;
    [SerializeField] 
    private float areaOneRadius;
    [SerializeField] 
    private float areaTwoRadius;
    [SerializeField] 
    private float areaThreeRadius;
    
    private float distanceFromAttractor;
    private Rigidbody rb;

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

        if (distanceFromAttractor < areaOneRadius)
        {
            Vector3 force = direction.normalized * attractorAreaOneForce;
            rbToAttract.AddForce(force);    
        }
        else if(distanceFromAttractor > areaOneRadius && distanceFromAttractor < areaTwoRadius)
        {
            Vector3 force = direction.normalized * attractorAreaTwoForce;
            rbToAttract.AddForce(force);
        }
        else if(distanceFromAttractor > areaTwoRadius && distanceFromAttractor < areaThreeRadius)
        {
            Vector3 force = direction.normalized * attractorAreaThreeForce;
            rbToAttract.AddForce(force);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, areaOneRadius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, areaTwoRadius);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, areaThreeRadius);
    }
}
