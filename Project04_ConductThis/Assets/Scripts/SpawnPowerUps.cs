using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUp : MonoBehaviour
{
    public int numberOfPowerUps = 10;       // How many power ups to spawn
    public float minXSpawn = 0f;            // The min x position that power ups can spawn
    public float maxXSpawn = 10f;           // The max x position that power ups can spawn
    public float ySpawn = 1f;               // The y position that all power ups will spawn
    public GameObject powerUpPrefab;        // The prefab of the power up to be spawned
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
        stats.myHealth = 100f;
        Destroy(gameObject);
    }
}
