using UnityEngine;

public class Player_Projectile_Movement : MonoBehaviour
{
    public float speed = 40f; 

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
