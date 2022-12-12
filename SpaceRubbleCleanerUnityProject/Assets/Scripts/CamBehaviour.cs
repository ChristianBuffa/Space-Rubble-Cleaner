using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamBehaviour : MonoBehaviour
{
    [SerializeField] 
    private AnimationCurve curve;
    [SerializeField] 
    private GameObject target;
    [SerializeField] 
    private float yInit;
    [SerializeField] 
    private float yMax;
    [SerializeField] 
    private float maxSpeed;
    [SerializeField]
    private Transform cameraMain;

    private float speedNormalized;
    private float distance;
    private float offset;
    private float speed;
    private Rigidbody targetRb;

    private void Start()
    {
        yInit = cameraMain.position.y;
        targetRb = target.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        speed = Mathf.Abs(targetRb.velocity.magnitude);
        
        speedNormalized = speed / maxSpeed;
        offset = curve.Evaluate(speedNormalized);
        distance = yMax * offset;
        distance = yMax * offset;
        cameraMain.position = new Vector3(target.transform.position.x , yInit + distance, target.transform.position.z);
    }
}
