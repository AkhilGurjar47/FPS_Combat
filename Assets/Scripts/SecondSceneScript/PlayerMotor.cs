using System.Globalization;
using UnityEngine;
public class PlayerMotor : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 playerVelocity;
    private bool IsGrounded;
    private float gravity = -9.81f;
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private float speed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        IsGrounded = characterController.isGrounded;
    }
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDir = Vector3.zero;
        moveDir.x = input.x;
        moveDir.z = input.y;
        characterController.Move(transform.TransformDirection(moveDir) * speed * Time.deltaTime);

        playerVelocity.y += gravity * Time.deltaTime;
        if(IsGrounded && playerVelocity.y <= 0)
        {
            playerVelocity.y = -2f;
        }
        characterController.Move(playerVelocity * Time.deltaTime);
    }
    public void Jump()
    {
        if (IsGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }
}
