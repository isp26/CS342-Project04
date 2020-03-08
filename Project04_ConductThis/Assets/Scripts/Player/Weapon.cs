using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    private PlayerController myPlayer;

    public float bulletForce = 20f;
    private LineRenderer lazer;
    public GameObject hitEffect;



    private void Awake() {
        myPlayer = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerController>();
        lazer = this.gameObject.GetComponent<LineRenderer>();
    }

    private void Update() {
        if (myPlayer.drillsPickup) { //Fire the lazer
            lazer.enabled = true;
            lazer.SetPosition(0, this.gameObject.transform.position);
            lazer.SetPosition(1, this.gameObject.transform.position + this.gameObject.transform.up * 100.0f);
            fireLazer();
        }
        else {
            lazer.enabled = false;
        }
        
        if(Input.GetButtonDown("Fire1") && !myPlayer.drillsPickup) {
            Shoot();
        }

    }

    private void fireLazer() {
        RaycastHit2D hitInfo = Physics2D.Raycast(this.gameObject.transform.position, this.gameObject.transform.up);
        Debug.DrawRay(this.transform.position, this.transform.up, Color.green);
        if(hitInfo.collider != null) {
            if (!hitInfo.collider.isTrigger) {
                GameObject effect = Instantiate(hitEffect, hitInfo.transform.position, hitInfo.transform.rotation);
                effect.transform.parent = this.gameObject.transform;

                AIController enemy = hitInfo.transform.GetComponent<AIController>();
                if(enemy != null) {
                    enemy.myHealth -= 2.0f;
                    enemy.slowed = true;
                }
            }
        }
    }

    private void Shoot() {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }


}
