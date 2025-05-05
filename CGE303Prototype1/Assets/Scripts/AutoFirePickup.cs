using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFirePickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        ShootProjectile shooter = other.GetComponent<ShootProjectile>();

        if (shooter != null)
        {
            shooter.SetAutomaticMode(true); // Switch to upgraded full-auto mode
            Destroy(gameObject);
        }
    }
}
