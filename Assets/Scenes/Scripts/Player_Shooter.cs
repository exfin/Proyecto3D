using UnityEngine;

public class Player_Shooter : MonoBehaviour
{
    public GameObject projectilePrefab;  // Prefab del proyectil
    public Transform firePoint;          // Punto de salida del proyectil
    public Camera cam;                   // Cámara del jugador

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instanciar el proyectil con la rotación de la cámara
        Instantiate(projectilePrefab, firePoint.position, cam.transform.rotation);
    }
}
