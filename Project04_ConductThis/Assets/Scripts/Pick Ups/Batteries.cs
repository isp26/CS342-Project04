using UnityEngine;

public class Batteries : MonoBehaviour
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
        player.gameObject.GetComponent<PlayerController>().batteriesPickup = true;
        player.gameObject.GetComponent<PlayerController>().timeSinceLastBatteriesPickup -= 6.0f;
        Destroy(gameObject);
    }
}
