using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        player.gameObject.GetComponent<PlayerController>().lightningBoltsCollected += 1;
        PlayerController stats = player.GetComponent<PlayerController>();
        stats.moveSpeed += 0.5f;
        Destroy(gameObject);
    }
}
