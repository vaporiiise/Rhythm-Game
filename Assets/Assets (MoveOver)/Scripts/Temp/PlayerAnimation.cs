using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public GameObject playerObject; // Assign this in the Inspector

    private Animator animator;
    private CharacterController controller;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private bool isGrounded;
    private float verticalVelocity = 0f;
    public float gravity = -9.81f;

    void Start()
    {
        animator = GetComponent<Animator>();
        controller = playerObject.GetComponent<CharacterController>(); // Reference controller on the assigned object
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Movement keys
        bool leftPressed = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S);
        bool rightPressed = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D);

        // Flip direction
        if (leftPressed)
            transform.localScale = new Vector3(-1, 1, 1);
        else if (rightPressed)
            transform.localScale = new Vector3(1, 1, 1);

        // Run animation
        animator.SetBool("IsRunning", leftPressed || rightPressed);

        
    }
}