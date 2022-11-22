using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed;
    [SerializeField]
    private float playerRotation;

    private CharacterController controller;

    private Vector2 playerInput;

    private void Start()
    {
        controller =  GetComponent<CharacterController>();        
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        controller.Move(transform.forward * playerInput.y * playerSpeed * Time.deltaTime);
        transform.Rotate(transform.up, playerRotation * playerInput.x * Time.deltaTime);
    }

    private void OnMovement(InputValue value)
    {
        playerInput = value.Get<Vector2>();
    }
}
