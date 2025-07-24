using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float moseSenstivity = 100f;
    [SerializeField] private Transform playerBody;
    private float xRotation = 0f;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * moseSenstivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * moseSenstivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
     }
}
