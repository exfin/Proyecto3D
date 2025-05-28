using UnityEngine;

public class Player_Shooter : MonoBehaviour
{
    public GameObject projectilePrefab;  
    public Transform firePoint;          
    public Camera cam;                   

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        
        Instantiate(projectilePrefab, firePoint.position, cam.transform.rotation);
    }
}
