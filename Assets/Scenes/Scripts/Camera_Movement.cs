using UnityEngine;

public class Camera_Movement : MonoBehaviour
{

    public float sensibilidad = 100f;
    float RotacionX = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Mouse X") * sensibilidad * Time.deltaTime;
        float moveY = Input.GetAxis("Mouse Y") * sensibilidad * Time.deltaTime;

        RotacionX -= moveY;
        RotacionX = Mathf.Clamp(RotacionX, -100f, -70f);

        transform.localRotation = Quaternion.Euler(RotacionX, 0f, 0f);
        
    }
}
