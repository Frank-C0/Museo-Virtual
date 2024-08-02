using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speedHorizontal = 10.0f;
    public float speedVertical = 5.0f;
    public float lookSensitivity = 2.0f;
    public float maxLookX = 45.0f;
    public float minLookX = -45.0f;
    private float rotX;
    private Rigidbody rb;
    private Camera playerCamera;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.drag = 0;
        rb.angularDrag = 0;
        rb.isKinematic = false; // Deja que el Rigidbody maneje colisiones pero sin inercia.

        playerCamera = GetComponentInChildren<Camera>();

        // Bloquea el cursor en el centro de la pantalla y lo oculta
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Move();
        CameraLook();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal") * speedHorizontal;
        float z = Input.GetAxis("Vertical") * speedVertical;
        float y = 0;
        if (Input.GetKey(KeyCode.E)) // Tecla para moverse hacia arriba
        {
            y = speedVertical;
        }
        else if (Input.GetKey(KeyCode.Q)) // Tecla para moverse hacia abajo
        {
            y = -speedVertical;
        }

        Vector3 movement = transform.right * x + transform.forward * z + transform.up * y;
        rb.velocity = movement;
    }

    void CameraLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity;
        rotX -= Input.GetAxis("Mouse Y") * lookSensitivity;
        rotX = Mathf.Clamp(rotX, minLookX, maxLookX);

        Quaternion deltaRotation = Quaternion.Euler(0, y, 0);
        rb.MoveRotation(rb.rotation * deltaRotation);
        playerCamera.transform.localRotation = Quaternion.Euler(rotX, 0, 0);
    }
}
