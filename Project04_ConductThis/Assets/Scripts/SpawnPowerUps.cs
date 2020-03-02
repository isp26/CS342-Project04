﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUp : MonoBehaviour
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

        if (timerPowerupOne % 500 == 0)
        {
            Vector3 location = new Vector3(Random.Range(-19.0f, 19.0f), Random.Range(-19.0f, 19.0f), 0.0f);
            Instantiate(powerupOne, location, Quaternion.Euler(0.0f, 0.0f, 0.0f));
        }

        if (timerPowerupTwo % 1000 == 0)
        {
            Vector3 location = new Vector3(Random.Range(-19.0f, 19.0f), Random.Range(-19.0f, 19.0f), 0.0f);
            Instantiate(powerupTwo, location, Quaternion.Euler(0.0f, 0.0f, 0.0f));
        }

        if (timerPowerupThree % 1500 == 0)
        {
            Vector3 location = new Vector3(Random.Range(-19.0f, 19.0f), Random.Range(-19.0f, 19.0f), 0.0f);
            Instantiate(powerupThree, location, Quaternion.Euler(0.0f, 0.0f, 0.0f));
        }
    }
}
