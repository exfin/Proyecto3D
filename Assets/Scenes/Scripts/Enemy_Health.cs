using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        GameManager.Instance.RegisterEnemy();
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            GameManager.Instance.UnregisterEnemy();
             Destroy(gameObject);
        }
    }
}
