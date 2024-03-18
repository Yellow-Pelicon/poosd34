using UnityEngine;

public class EnemyOneBehavior : MonoBehaviour
{
    public float fallSpeed = 5.0f;
    public float cloneInterval = 3.0f;
    public int maxClones = 5;
    public int enemyHealth = 20;
    public int damageAmount = 5; // Damage taken from bullets
    private float cloneTimer;
    private static int currentClones = 0;
    public bool isOriginal = true;

    void Start()
    {
        cloneTimer = cloneInterval;
        if (isOriginal)
        {
            transform.position = new Vector3(0, 1000, 0); // Move original off-screen
        }
    }

    void Update()
    {
        if (isOriginal)
        {
            if (currentClones < maxClones)
            {
                cloneTimer -= Time.deltaTime;
                if (cloneTimer <= 0)
                {
                    CloneEnemy();
                    cloneTimer = cloneInterval;
                }
            }
        }
        else
        {
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

            if (Camera.main != null && transform.position.y < Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y)
            {
                currentClones--;
                Destroy(gameObject);
            }
        }
    }

    private void CloneEnemy()
    {
        GameObject clone = Instantiate(gameObject, new Vector3(0, 0, 0), Quaternion.identity);
        EnemyOneBehavior cloneScript = clone.GetComponent<EnemyOneBehavior>();
        if (cloneScript != null)
        {
            cloneScript.isOriginal = false;
            cloneScript.SetRandomStartPosition();
            currentClones++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isOriginal) // Ensure this is a clone
        {
            if (collision.CompareTag("Player"))
            {
                CharacterBehavior characterBehavior = collision.gameObject.GetComponent<CharacterBehavior>();
                if (characterBehavior != null)
                {
                    characterBehavior.TakeDamage(damageAmount);
                }
                Destroy(gameObject); // Destroy this enemy
            }
            else if (collision.CompareTag("Bullet")) // Check collision with bullet
            {
                // Reduce health by the damage amount
                enemyHealth -= damageAmount;

                // Check if health is less or equal to zero
                if (enemyHealth <= 0)
                {
                    currentClones--;
                    Destroy(gameObject); // Destroy this enemy
                }
                // Destroy the bullet upon collision
                Destroy(collision.gameObject);
            }
        }
    }

    public void SetRandomStartPosition()
    {
        if (!isOriginal)
        {
            if (Camera.main != null)
            {
                float screenWidth = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
                float randomX = Random.Range(-screenWidth, screenWidth);
                transform.position = new Vector3(randomX, Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y, 0);
            }
        }
    }
}
