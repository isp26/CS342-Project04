using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batteries : MonoBehaviour
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
        player.gameObject.GetComponent<PlayerController>().batteriesCollected += 1;
        PlayerController stats = player.GetComponent<PlayerController>();
        stats.myHealth = 100f;
        Destroy(gameObject);
    }
}
