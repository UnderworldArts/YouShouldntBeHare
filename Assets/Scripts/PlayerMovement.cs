using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    private float moveSpeed; // Speed at which the player moves
    public float walkSpeed; // Speed when walking
    public float sprintSpeed; // Speed when sprinting

    public float groundDrag; // Drag applied to the player when grounded



    [Header("Jumping")]
    public float jumpForce; // Force applied to the player when jumping
    public float jumpCooldown; // Cooldown time between jumps
    public float airMultiplier; // Multiplier for movement speed in the air

    [Header("Crouching")]
    public float crouchSpeed; // Speed when crouching
    public float crouchYscale; // Scale of the player when crouching
    private float startYscale; // Original scale of the player before crouching

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space; // Key to trigger jumping
    public KeyCode sprintKey = KeyCode.LeftShift; // Key to trigger sprinting
    public KeyCode crouchKey = KeyCode.LeftControl; // Key to trigger crouching

    [Header("Ground Check")]
    public float playerHeight; // Height of the player for ground checking
    public LayerMask whatIsGround; // Layer mask to identify ground objects
    bool grounded; // Flag to check if the player is grounded
    bool readyToJump; // Flag to check if the player is ready to jump


    public Transform orientation; // Reference to the player's orientation

    float horizontalInput; // Horizontal input from the player
    float verticalInput;// Vertical input from the player

    Vector3 moveDirection;

    Rigidbody rb;

    // Movement state enumeration to track the player's movement state
    public enum MovementState
    {
        walking,
        sprinting,
        crouching,
        air
    }

    private MovementState state;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true; // Initialize the jump readiness flag

        startYscale = transform.localScale.y; // Store the original scale of the player
    }

    void Update()
    {
        // Ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround); // Check if the player is grounded using a raycast

        //Handle drag
        if (grounded)
        {
            rb.linearDamping = groundDrag;
        }
        else
        {
            rb.linearDamping = 0;
        }



        MyInput();
        SpeedControl();
        StateHandler();
    }   

    void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal"); // Get horizontal input (A/D or Left/Right)
        verticalInput = Input.GetAxisRaw("Vertical"); // Get vertical input (W/S or Up/Down)

        // Jumping
        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            Debug.Log("Jumping"); 

            readyToJump = false; // Set the jump readiness flag to false

            Jump(); // Call the Jump method to apply jump force

            Invoke(nameof(ResetJump), jumpCooldown); // Schedule the ResetJump method to be called after the jump cooldown
        }

        // Crouching
        if(Input.GetKeyDown(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYscale, transform.localScale.z); // Scale the player down for crouching
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse); // Apply a downward force to the player when crouching
        }

        // Stop crouching
        if(Input.GetKeyUp(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, startYscale, transform.localScale.z); // Reset the player's scale to the original value
        }

    }


    // Handle the player's movement state based on input and grounded status
    private void StateHandler()
    {
        // Mode - Crouching
        if (Input.GetKey(crouchKey))
        {
            state = MovementState.crouching;
            moveSpeed = crouchSpeed;
        }


        // Mode - Sprinting
        if (grounded && Input.GetKey(sprintKey))
        {
            state = MovementState.sprinting; 
            moveSpeed = sprintSpeed; 
        }
        // Mode - Walking
        else if (grounded)
        {
            state = MovementState.walking;
            moveSpeed = walkSpeed;
        }
        // Mode - Air
        else
        {
            state = MovementState.air;
            moveSpeed = walkSpeed; 
        }
    }



    private void MovePlayer()
    {
        // Calculate the movement direction based on player input and orientation
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        
        //On ground
        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force); // Apply movement force when grounded
        //In air
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force); // Apply movement force when in the air with air multiplier




    }


    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z); // Get the player's velocity in the horizontal plane


        // Limit the player's speed to the specified moveSpeed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed; // Calculate the limited velocity
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z); // Apply the limited velocity while preserving vertical velocity
        }
    }

    private void Jump()
    {
        // Reset vertical velocity before jumping
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        // Apply jump force to the player's Rigidbody
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true; // Reset the jump readiness flag
    }  

}
