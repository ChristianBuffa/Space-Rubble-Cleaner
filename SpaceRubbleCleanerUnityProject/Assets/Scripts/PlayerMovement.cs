using UnityEditor;
using UnityEngine;
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
        ManageInput();
        Movement();
    }

    private void Movement()
    {
        fuelSlider.value = currentFuel / maxFuel;

        if (currentFuel > 0)
        {
            rb.AddForce(transform.forward * playerInput.y * playerSpeed * Time.deltaTime, ForceMode.VelocityChange);
            transform.Rotate(transform.up, playerRotation * playerInput.x * Time.deltaTime);
        }
    }

    private void ManageInput()
    {
        playerInput.y = Input.GetAxis("Vertical");  
        playerInput.x = Input.GetAxis("Horizontal");

        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            currentFuel -= fuelBurnRate * Time.deltaTime;
        }
    }
}
