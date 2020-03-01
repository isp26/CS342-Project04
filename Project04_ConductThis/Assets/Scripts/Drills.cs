using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drills : MonoBehaviour
{
    public GameObject pickupEffect;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }

    }

    void Pickup(Collider2D player)
    {
        Weapon stats = GameObject.Find("FirePoint").GetComponent<Weapon>();
        stats.maxAmmo += 1;
        Destroy(gameObject);
    }
}
