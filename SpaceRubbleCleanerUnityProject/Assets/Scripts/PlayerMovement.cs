using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] 
    private float maxFuel;
    [SerializeField] 
    private float fuelBurnRate;
    [SerializeField]
    private float playerSpeed;
    [SerializeField]
    private float playerRotation;
    [SerializeField] 
    private Slider fuelSlider;

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
        fuelSlider.value = currentFuel / maxFuel;
        
        rb.AddForce(transform.forward * playerInput.y * playerSpeed * Time.deltaTime, ForceMode.VelocityChange);
        transform.Rotate(transform.up, playerRotation * playerInput.x * Time.deltaTime);
    }

    private void OnMovement(InputValue value)
    {
        if (currentFuel > 0)
        {
            currentFuel -= fuelBurnRate * Time.deltaTime;
            playerInput = value.Get<Vector2>();
        }
        else
        {
            playerInput = Vector2.zero;
        }
    }
}
