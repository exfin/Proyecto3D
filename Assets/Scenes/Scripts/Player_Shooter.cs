using UnityEngine;

public class Player_Shooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public Camera cam;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip shootSound;

    public float shootCooldown = 1.5f;
    private float lastShootTime = -Mathf.Infinity;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= lastShootTime + shootCooldown)
        {
            lastShootTime = Time.time;

            if (audioSource != null && shootSound != null)
                audioSource.PlayOneShot(shootSound);

            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(projectilePrefab, firePoint.position, cam.transform.rotation);
    }
}
