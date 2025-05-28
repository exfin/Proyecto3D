using UnityEngine;

public class Player_Damage : MonoBehaviour
{
    public int damage = 25;
    

    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Enemy_Health enemy = other.GetComponent<Enemy_Health>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject); 
        }
    }
}
