using UnityEngine;

public class Camera_Movement : MonoBehaviour
{

    public float sensibilidad = 100f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Mouse X") * sensibilidad * Time.deltaTime;
        float moveY = Input.GetAxis("Mouse Y") * sensibilidad * Time.deltaTime;

        
    }
}
