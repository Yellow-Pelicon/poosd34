using UnityEngine;

public class CharacterShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootingPoint;
    public float bulletSpeed = 20.0f;

    public Weapon currentWeapon;

    void Update()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            currentWeapon.TryShoot();
        }
    }
    
    public void ChangeWeapon(Weapon newWeapon)
    {
        currentWeapon = newWeapon;
        // Update the UI or any other elements here
    }
    
    public void fireBullet()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // Instantiate the bullet
            GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);
            // Access the Bullet script component of the new bullet instance and set its speed
            BulletMechanics bulletMechanicsComponent = bullet.GetComponent<BulletMechanics>();
            if (bulletMechanicsComponent != null) // Check if the Bullet component is attached to the prefab
            {
                bulletMechanicsComponent.speed = 10; // Set the bullet's speed
            }
        }
    }
}
