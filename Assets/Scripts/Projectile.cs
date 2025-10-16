using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 50f;

    private GameObject shooter;

    void Update()
    {
        transform.position += speed * Time.deltaTime * transform.forward;
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
