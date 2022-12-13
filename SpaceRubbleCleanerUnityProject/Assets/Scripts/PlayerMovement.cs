using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] [Tooltip("Forza massima raggiungibile dal Rigidbody")]
    private float maxSpeed;
    [SerializeField] 
    private float maxFuel;
    [SerializeField] 
    private float fuelBurnRate;
    [SerializeField][Tooltip("Forza applicata al Rigidbody")]
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

        if (rb.velocity.z > maxSpeed)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, maxSpeed);
        }
        if (rb.velocity.x > maxSpeed)
        {
            rb.velocity = new Vector3(maxSpeed, 0, rb.velocity.z);
        }
        
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            currentFuel -= fuelBurnRate * Time.deltaTime;
        }
    }
}
