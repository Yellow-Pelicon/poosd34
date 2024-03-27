using UnityEngine;
/// <summary>
///  Weapon class is a base class for all weapons in the game.
/// </summary>
public class Weapon
{
    public bool IsUnlocked;
    public string Name;
    public float FireRate;
    public float Damage;
    public GameObject BulletPrefab;
    public RuleTile.TilingRuleOutput.Transform ShootingPoint;

    private float _nextFireTime = 0f;
    
    /// <summary>
    /// Initialize the weapon with the given parameters.
    /// </summary>
    /// <param name="isUnlocked">Is the weapon unlocked?</param>
    /// <param name="name">Name of the weapon.</param>
    /// <param name="fireRate">FireRate of the weapon.</param>
    /// <param name="damage">Damage of the weapon's bullets.</param>
    /// <returns></returns>
    public void Initialize(bool isUnlocked, string name, float fireRate, float damage)
    {
        this.IsUnlocked = isUnlocked;
        this.Name = name;
        this.FireRate = fireRate;
        this.Damage = damage;
    }

    /// <summary>
    /// Checks if the weapon can shoot depending on the fire rate.
    /// </summary>
    public void TryShoot()
    {
        if (Time.time > nextFireTime)
        {
            Shoot();
            _nextFireTime = Time.time + 1f / fireRate;
        }
    }
    
    /// <summary>
    /// Shoots the weapon by instantiating a bullet prefab.
    /// </summary>
    protected virtual void Shoot()
    {
        Instantiate(BulletPrefab, ShootingPoint.position, Quaternion.identity);
        // You can add more logic here for the shooting behavior
    }
}
