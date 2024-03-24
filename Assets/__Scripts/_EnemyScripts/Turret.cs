using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float fireRate = 1f; // Time between each shot
    public Vector2 fireDirection = Vector2.up; // Direction to fire projectiles
    public float projectileLifetime = 3f;

    private float nextFireTime = 0f;

    void Update()
    {
        // Check if it's time to fire
        if (Time.time >= nextFireTime)
        {
            FireProjectile();
            nextFireTime = Time.time + fireRate; // Update the next fire time
        }
    }

    void FireProjectile()
    {
        // Instantiate projectile
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Projectile projectileScript = projectile.GetComponent<Projectile>();

        // Set the direction of the projectile
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = fireDirection.normalized * 20;

        // Set the fromWhere field in the projectile script
        projectileScript.fromWhere = gameObject;

        Destroy(projectile, projectileLifetime);
    }
}
