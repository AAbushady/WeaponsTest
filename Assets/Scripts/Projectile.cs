using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Projectile Settings")]
    public float speed;
    public float lifetime;

    private GameObject shooter;
    private float spawnTime;
    private Rigidbody rb;

    void Start()
    {
        spawnTime = Time.time;
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = speed * transform.forward;
    }

    void Update()
    {        
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
       HandleImpact(other.gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        HandleImpact(collision.gameObject);
    }

    private void HandleImpact(GameObject hitObject)
    {
        // Only check parent if shooter still exists
        if (shooter != null)
        {
            if (hitObject == shooter || hitObject.transform.IsChildOf(shooter.transform))
            {
                return; // Ignore collision with shooter or its children
            }
        }
        // Hit something valid (or shooter was destroyed, treat as valid hit)
        Debug.Log($"Bullet hit: {hitObject.name}");
        Destroy(this.gameObject);
    }
}
