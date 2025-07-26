using Unity.Android.Gradle.Manifest;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    private float gravity = -9.81f;
    private float jumpHeight = 3f;
    private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform groundCheck;
    private Vector3 velocity;
    private bool isGrounded;
    private float walkSpeed = 5f;
    private float runSpeed = 10f;
    private float currentSpeed;
    private CharacterController characterController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0 ) 
        {
            velocity.y = -2f;
        }
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        if(Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = runSpeed;
        }
        else
        {
            currentSpeed = walkSpeed;
        }
        velocity.y += gravity * Time.deltaTime;
        Vector3 move = transform.right * horizontal + transform.forward * vertical;

        characterController.Move(move * currentSpeed * Time.deltaTime + Vector3.up * velocity.y * Time.deltaTime);
    }
}
