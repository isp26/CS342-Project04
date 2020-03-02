using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    private float timerPowerupOne;
    private float timerPowerupTwo;
    private float timerPowerupThree;

    public GameObject powerupOne;
    public GameObject powerupTwo;
    public GameObject powerupThree;


    private void Update()
    {
        spawnPowerUps();
    }

    private void spawnPowerUps()
    {

        timerPowerupOne += Time.deltaTime;
        timerPowerupTwo += Time.deltaTime;
        timerPowerupThree += Time.deltaTime;

        if (Mathf.Round(timerPowerupOne) / 5 >= 1)
        {
            Vector3 location = new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f), 0.0f);
            Instantiate(powerupOne, location, Quaternion.Euler(0.0f, 0.0f, 0.0f));
            timerPowerupOne = 0.0f;
        }

        if (Mathf.Round(timerPowerupTwo) / 5 >= 1)
        {
            Vector3 location = new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f), 0.0f);
            Instantiate(powerupTwo, location, Quaternion.Euler(0.0f, 0.0f, 0.0f));
            timerPowerupTwo = 0.0f;
        }

        if (Mathf.Round(timerPowerupThree) / 5 >= 1)
        {
            Vector3 location = new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f), 0.0f);
            Instantiate(powerupThree, location, Quaternion.Euler(0.0f, 0.0f, 0.0f));
            timerPowerupThree = 0.0f;
        }
    }
}