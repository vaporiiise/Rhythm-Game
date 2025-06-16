using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;                // Normal walking speed
    public float sprintSpeed = 10f;         // Speed while holding Left Shift
    public float gravity = -9.81f;          // Gravity force
    public Transform groundCheck;           // Position to check if grounded
    public float groundDistance = 0.4f;     // Radius for ground check
    public LayerMask groundMask;            // Which layers count as ground

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -4f; 
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : speed;

        Vector3 move = Vector3.right * x + Vector3.forward * z;
        controller.Move(move * currentSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}