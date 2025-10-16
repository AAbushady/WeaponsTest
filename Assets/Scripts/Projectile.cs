using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Projectile Settings")]
    public float speed;
    public float lifetime;

    private GameObject shooter;
    private float spawnTime;

    void Start()
    {
        spawnTime = Time.time;
    }

    void Update()
    {
        // Move the projectile
        transform.position += speed * Time.deltaTime * transform.forward;
        
        // Check lifetime
        if (Time.time - spawnTime >= lifetime)
        {
            Destroy(this.gameObject);
        }
    }

    public void SetShooter(GameObject shooter)
    {
        this.shooter = shooter;
    }

    void OnTriggerEnter(Collider other)
    {
        // Only check parent if shooter still exists
        if (shooter != null)
        {
            if (other.gameObject == shooter || other.transform.IsChildOf(shooter.transform))
            {
                return; // Ignore collision with shooter or its children
            }
        }

        // Hit something valid (or shooter was destroyed, treat as valid hit)
        Debug.Log($"Bullet hit: {other.gameObject.name}");
        Destroy(this.gameObject);
    }
}
