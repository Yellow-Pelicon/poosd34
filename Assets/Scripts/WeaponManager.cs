public class WeaponManager : MonoBehaviour
{
    public List<Weapon> weapons;
    private int currentWeaponIndex;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) // Assuming Q switches weapons
        {
            currentWeaponIndex = (currentWeaponIndex + 1) % weapons.Count;
            GetComponent<CharacterShooting>().ChangeWeapon(weapons[currentWeaponIndex]);
        }
    }
}

