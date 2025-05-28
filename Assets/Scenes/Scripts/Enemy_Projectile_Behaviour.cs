using UnityEngine;

public class Enemy_Projectile_Behaviour : MonoBehaviour
{

    public float speed = 10f;

    void Start()
    {
        Destroy(gameObject, 4f);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
