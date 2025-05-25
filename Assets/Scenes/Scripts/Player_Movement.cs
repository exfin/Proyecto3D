using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float moveSpeed = 5f;      
    public float rotationSpeed = 100f; 

    
    void Update()
    {
        
        float moveDirection = 0f;
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveDirection = -1f;
        }
        transform.Translate(Vector3.forward * moveDirection * moveSpeed * Time.deltaTime);

        
        float rotationDirection = 0f;
        if (Input.GetKey(KeyCode.A))
        {
            rotationDirection = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rotationDirection = 1f;
        }
        transform.Rotate(Vector3.up, rotationDirection * rotationSpeed * Time.deltaTime);
    }
}
