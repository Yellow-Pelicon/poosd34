using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private float horizontalMovement = 0f;
    public int health = 20;
    public HealthBar healthBar;

    void start()
    {
        healthBar.SetHealth(health);
    }
    void Update()
    {
        // This ensures the player moves based on the current horizontalMovement value
        Vector3 movement = new Vector3(horizontalMovement, 0, 0);
        transform.Translate(movement * speed * Time.deltaTime);
    }

    // Call this method when the "Move Left" button is pressed down
    public void MoveLeft()
    {
        horizontalMovement = -1f;
    }

    // Call this method when the "Move Right" button is pressed down
    public void MoveRight()
    {
        horizontalMovement = 1f;
    }

    // Call this method when either the "Move Left" or "Move Right" button is released
    public void StopMoving()
    {
        horizontalMovement = 0f;
    }

    // Handle the player taking damage
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        // Update the health bar when taking damage
        if (healthBar != null)
        {
            healthBar.SetHealth(health);
        }

        // Check if health fell below zero and handle accordingly
        if (health <= 0)
        {
            Debug.Log("Player defeated");
            Destroy(gameObject);
            // Additional actions in the future maybe??
        }
    }
}
