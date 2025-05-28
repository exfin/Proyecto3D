using UnityEngine;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthBar;

    void Start()
    {
        maxHealth = health;
        UpdateHealthUI();
    }

    void Update()
    {
        UpdateHealthUI();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        health = Mathf.Clamp(health, 0, maxHealth);

        if (health <= 0)
        {
            GameManager.Instance.PlayerDied();
        }
    }

    void UpdateHealthUI()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = Mathf.Clamp01(health / maxHealth);
        }
    }
}
