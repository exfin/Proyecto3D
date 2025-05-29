using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip explosionSound;

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
            if (audioSource != null && explosionSound != null)
                audioSource.PlayOneShot(explosionSound);
            GameManager.Instance.UnregisterEnemy();
             Destroy(gameObject);
        }
    }
}
