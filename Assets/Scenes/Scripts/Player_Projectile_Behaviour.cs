using UnityEngine;

public class Player_Projectile_Behaviour : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 4f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
