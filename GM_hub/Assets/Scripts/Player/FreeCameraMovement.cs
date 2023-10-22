using UnityEngine;
using UnityEngine.InputSystem;

public class FreeCameraMovement : MonoBehaviour
{
    [SerializeField] private InputAction moveAction;
    [SerializeField] private InputAction rotateAction;
    [SerializeField] private InputAction zoomAction;
    [SerializeField] private TextDisplay textDisplay;

    [SerializeField] private float maxMoveSpeed = 10f;
    [SerializeField] private float rotateSpeed = 2f;
    [SerializeField] private float zoomSpeed = 5f;
    [SerializeField] private float orbitSpeed = 2f;
    [SerializeField] private float minVerticalAngle = -80f;
    [SerializeField] private float maxVerticalAngle = 80f;

    private Vector2 moveInput;
    private Vector2 rotateInput;
    private float zoomInput;
    private Vector3 cameraRotation;
    private Rigidbody rb;
    private float moveSpeed = 5f;

    private bool isCursorLocked = true;

    private void OnEnable()
    {
        moveAction.Enable();
        rotateAction.Enable();
        zoomAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        rotateAction.Disable();
        zoomAction.Disable();
    }

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Move the camera
        moveInput = moveAction.ReadValue<Vector2>();

        var finalMoveSpeed = moveSpeed;

        if(Input.GetKey(KeyCode.LeftShift)) finalMoveSpeed = moveSpeed * 2f;

        rb.AddForce(transform.forward * moveInput.y * finalMoveSpeed * Time.deltaTime, ForceMode.Impulse);
        rb.AddForce(transform.right * moveInput.x * finalMoveSpeed * Time.deltaTime, ForceMode.Impulse);

        // Rotate the camera
        if(Input.GetKey(KeyCode.Mouse1))
        {
            Cursor.lockState = CursorLockMode.Locked;

            var scroll = zoomAction.ReadValue<float>();

            if(scroll > 0 && moveSpeed < maxMoveSpeed) ChangeSpeedUsingScroll(1);
            if(scroll < 0 && moveSpeed > 0) ChangeSpeedUsingScroll(-1);


            rotateInput = rotateAction.ReadValue<Vector2>();
            cameraRotation.x -= rotateInput.y * rotateSpeed * Time.deltaTime;
            cameraRotation.y += rotateInput.x * rotateSpeed * Time.deltaTime;
            cameraRotation.x = Mathf.Clamp(cameraRotation.x, minVerticalAngle, maxVerticalAngle);
            transform.rotation = Quaternion.Euler(cameraRotation);
        }

        if(Input.GetKeyUp(KeyCode.Mouse1) || Input.GetKeyUp(KeyCode.Mouse1)) Cursor.lockState = CursorLockMode.None;
    }

    private void ChangeSpeedUsingScroll(int i)
    {
        moveSpeed += i;

        textDisplay.DisplayText("speed: x" + moveSpeed);
    }
}
