using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBolts : MonoBehaviour
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

        PlayerController stats = player.GetComponent<PlayerController>();
        stats.moveSpeed += 5;
        Destroy(gameObject);
    }
}
