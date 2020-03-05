using UnityEngine;

public class Drills : MonoBehaviour
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
        player.gameObject.GetComponent<PlayerController>().drillsPickup = true;
        player.gameObject.GetComponent<PlayerController>().timeSinceLastDrillsPickup -= 3.0f;
        Destroy(gameObject);
    }
}
