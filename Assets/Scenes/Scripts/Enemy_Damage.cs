using UnityEngine;

public class Enemy_Damage : MonoBehaviour
{
    
    public float damage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player_Health>().health -= damage;
            Destroy(gameObject);

        }
    }
}
