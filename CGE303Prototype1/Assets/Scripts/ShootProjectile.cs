using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;

    public float fireRate = 0.2f; // Time between shots in auto mode
    private float fireCooldown = 0f;

    private bool hasAutoMode = false; // Becomes true after pickup
    private bool isAutomatic = false; // Controls firing style after pickup

    void Update()
    {
        if (!hasAutoMode)
        {
            // Default basic shooting, no cooldown
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        else
        {
            // Upgraded firing mode (uses cooldown and full-auto if enabled)
            fireCooldown -= Time.deltaTime;

            if (isAutomatic)
            {
                if (Input.GetButton("Fire1") && fireCooldown <= 0f)
                {
                    Shoot();
                    fireCooldown = fireRate;
                }
            }
            else
            {
                if (Input.GetButtonDown("Fire1") && fireCooldown <= 0f)
                {
                    Shoot();
                    fireCooldown = fireRate;
                }
            }
        }
    }

    void Shoot()
    {
        GameObject firedProjectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Destroy(firedProjectile, 3f);
    }

    public void SetAutomaticMode(bool enableAuto)
    {
        hasAutoMode = true;    // enable upgraded firing system
        isAutomatic = enableAuto; // set whether it's full-auto or semi-auto inside the upgrade
    }
}

