using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class SimpleGun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireRate = 10f; // Rounds per second

    [Header("Visual Effects")]
    public GameObject muzzleFlash;

    private float lastFireTime;
    private float delayTime = 1.0f;

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= lastFireTime + (delayTime / fireRate))
        {
            Fire();
        }
    }

    void Fire()
    {
        GameObject childObject = null;

        if (bulletPrefab != null)
        {
            Quaternion aimDirection = transform.rotation; // Default to forward direction

            if (transform.childCount > 0)
            {
                AimingController aimingController = transform.GetChild(0).GetComponent<AimingController>();
                if (aimingController != null && aimingController.playerCamera != null)
                {
                    aimDirection = Quaternion.LookRotation(aimingController.GetAimDirection());
                }

                childObject = transform.GetChild(0).gameObject;

                Vector3 bulletSpawnPoint = childObject.transform.position + childObject.transform.forward * 2;

                if (muzzleFlash != null)
                {
                    Instantiate(muzzleFlash, bulletSpawnPoint, aimDirection);
                }

                GameObject newBullet = Instantiate(bulletPrefab, bulletSpawnPoint, aimDirection);

                // should set shooter to child of Player
                newBullet.GetComponent<Projectile>().SetShooter(childObject);

                lastFireTime = Time.time + (delayTime / fireRate);
            }
        }
        else
        {
            Debug.LogWarning("Bullet prefab not assigned!");
        }
    }
}
