public class Weapon
{
    public string name;
    public float fireRate;
    public GameObject bulletPrefab;
    public Transform shootingPoint;

    private float nextFireTime = 0f;

    public void TryShoot()
    {
        if (Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);
        // You can add more logic here for the shooting behavior
    }
}
