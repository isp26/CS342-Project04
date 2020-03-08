using UnityEngine;

public class LightningBolts : MonoBehaviour
{
    //public GameObject pickupEffect;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }

    }

    void Pickup(Collider2D player)
    {
        player.gameObject.GetComponent<PlayerController>().lightningBoltsPickup = true;
        player.gameObject.GetComponent<PlayerController>().timeSinceLastLightningBoltsPickup -= 7.0f;
        Destroy(gameObject);
    }
}
