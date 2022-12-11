using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] 
    private float maxFuel;
    [SerializeField]
    private float playerSpeed;
    [SerializeField]
    private float playerRotation;

    private Rigidbody rb;
    private float currentFuel;

    private Vector2 playerInput;

    private void Start()
    {
        rb =  GetComponent<Rigidbody>();
        currentFuel = maxFuel;
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        rb.AddForce(transform.forward * playerInput.y * playerSpeed * Time.deltaTime, ForceMode.VelocityChange);
        transform.Rotate(transform.up, playerRotation * playerInput.x * Time.deltaTime);
    }

    private void OnMovement(InputValue value)
    {
        playerInput = value.Get<Vector2>();
    }
}
