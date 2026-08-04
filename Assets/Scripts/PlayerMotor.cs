using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float speed;
    public float walkSpeed = 5.0f;
    public float sprintSpeed = 10.0f;
    public float crouchSpeed = 2.5f;

    private bool isGrounded;
    public float gravity = -9.8f;
    public float jumpHeight = 3.0f;

    bool crouching;
    float crouchTimer;
    bool lerpCrouch;
    bool sprinting;



    // Movement state enumeration to track the player's movement state
    public enum MovementState
    {
        walking,
        sprinting,
        crouching,
        air
    }

    private MovementState state;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
        
        if(lerpCrouch)
        {
            float p = crouchTimer / 1;
            p *= p;
            if (crouching)
            {
                controller.height = Mathf.Lerp(controller.height, 1, p);
            }
            else
            {
                controller.height = Mathf.Lerp(controller.height, 2, p);
            }

            if (p > 1)
            {
                lerpCrouch = false;
                crouchTimer = 0;
            }
        }
    }
    //Receive the inputs from our InputManager.cs and apply them to our character controller
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        Debug.Log(playerVelocity.y);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }   

    public void Crouch()
    {
        state = MovementState.crouching;
        crouching = !crouching;
        lerpCrouch = true;
        crouchTimer = 0;
        speed = crouchSpeed;
    }

    public void Sprint()
    {
        state = MovementState.sprinting;
        sprinting = !sprinting;
        if (sprinting)
        {
            speed = sprintSpeed;
        }
        else
        {
            speed = walkSpeed;
        }
    }

}
