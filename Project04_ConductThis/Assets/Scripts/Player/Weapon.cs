using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    public int maxAmmo = 6;
    private int currentAmmo;
    public float reloadTime = 2f;
    private bool isReloading = false;

    void Start()
    {
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {

        if (isReloading)
            return;
        if (currentAmmo <= 0 || Input.GetKeyDown(KeyCode.R))
        {
            if (currentAmmo == maxAmmo)
                return;
            StartCoroutine(Reload());
            return;
        }
        
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
    }

    void Shoot()
    {
        currentAmmo--;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }


}
