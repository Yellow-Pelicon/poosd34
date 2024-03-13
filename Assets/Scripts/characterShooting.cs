using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootingPoint;
    public float bulletSpeed = 20.0f;

    public void fireBullet()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // Instantiate the bullet
            GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);
            // Access the Bullet script component of the new bullet instance and set its speed
            Bullet bulletComponent = bullet.GetComponent<Bullet>();
            if (bulletComponent != null) // Check if the Bullet component is attached to the prefab
            {
                bulletComponent.speed = 10; // Set the bullet's speed
            }
        }
    }
}
