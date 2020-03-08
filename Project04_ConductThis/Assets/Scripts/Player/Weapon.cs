using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    private PlayerController myPlayer;

    public float bulletForce = 20f;
    private LineRenderer lazer;
    public GameObject hitEffect;
    public GameObject newLazer;

    public AudioClip lazerBeamSound;
    public AudioClip shotsSound;

    AudioSource audioSource;
    private void Awake() {
        myPlayer = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerController>();
        lazer = this.gameObject.GetComponent<LineRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update() {
        if (myPlayer.drillsPickup) { //Fire the lazer
            /*lazer.enabled = true;
            lazer.SetPosition(0, this.gameObject.transform.position);
            lazer.SetPosition(1, this.gameObject.transform.position + this.gameObject.transform.up * 100.0f);
            */
            //GameObject = Instantiate(newLazer, this.gameObject.transform.position, this.gameObject.transform.rotation);
            newLazer.SetActive(true);
            audioSource.PlayOneShot(lazerBeamSound, 0.3f);
            fireLazer();

        }
        else {
            newLazer.SetActive(false);
        }
        
        if(Input.GetButtonDown("Fire1") && !myPlayer.drillsPickup) {
            audioSource.PlayOneShot(shotsSound);
            Shoot();
            
        }

    }

    private void fireLazer()
    {
        RaycastHit2D[] hitInfo = Physics2D.CircleCastAll(this.gameObject.transform.position, 1.0f, this.gameObject.transform.up); //Raycast(this.gameObject.transform.position, this.gameObject.transform.up);
        Debug.DrawRay(this.transform.position, this.transform.up, Color.green);
        foreach (RaycastHit2D hit in hitInfo)
        {
            if (hit.collider != null)
            {
                if (!hit.collider.isTrigger)
                {
                    AIController enemy = hit.transform.GetComponent<AIController>();
                    if (enemy != null)
                    {
                        enemy.myHealth -= 2.0f;
                        enemy.slowed = true;

                        GameObject effect = Instantiate(hitEffect, hit.transform.position, hit.transform.rotation);
                        effect.transform.parent = this.gameObject.transform;
                    }
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
