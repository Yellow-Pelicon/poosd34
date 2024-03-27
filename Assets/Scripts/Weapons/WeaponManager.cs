using UnityEngine;

/// <summary>
/// WeaponManager class is responsible for managing the weapons in the game.
/// The player can switch between weapons using the Q key. (To be changed to a screen button).
/// </summary>
public class WeaponManager : MonoBehaviour
{
    public List<Weapon> weapons;
    private int currentWeaponIndex;

    /// <summary>
    /// Initialize the weapon manager with a list of weapons.
    /// </summary>
    /// <remarks>
    /// The basic weapon is always unlocked and is the first weapon in the list.
    /// The rifle and machine gun are locked by default, and must be unlocked by the player.
    /// Note: This technique for initializing weapons is being used to make it easier to apply upgrades to the weapons.
    /// </remarks>
    void Start()
    {
        Weapon basic = new Weapon();
        basic.Initialize(true,"Basic",2, 10);
        weapons.Add(basic);

        Weapon rifle = new Weapon();
        rifle.Initialize(false,"Rifle",2, 20);
        weapons.Add(rifle);

        Weapon machineGun = new Weapon();
        machineGun.Initialize(false,"MachineGun",10,2)
        weapons.Add(machineGun);

        currentWeaponIndex = 0;
        GetComponent<CharacterShooting>().ChangeWeapon(weapons[currentWeaponIndex]);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) // Assuming Q switches weapons
        {
            currentWeaponIndex = (currentWeaponIndex + 1) % weapons.Count;
            GetComponent<CharacterShooting>().ChangeWeapon(weapons[currentWeaponIndex]);
        }
    }
}

