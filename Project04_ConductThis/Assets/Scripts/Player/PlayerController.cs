using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    private float baseMovementSpeed;
    private float currentMovementSpeed;

    public float myHealth;
    public float maxHealth;
    public bool canBeHurt;
    public int playerScore;
    public Slider healthbar;
    public GameObject scoreText;
    private Text scoreDisplay;
    public Camera cam;

    private Rigidbody2D rb;
    private SpriteRenderer myRenderer;
    private float currentTimer;
    private float iFrameTimer;

    public bool lightningBoltsPickup;
    public bool batteriesPickup;
    public bool drillsPickup;

    public float timeSinceLastLightningBoltsPickup;
    public float timeSinceLastBatteriesPickup;
    private float intervalHealth;
    public float timeSinceLastDrillsPickup;
    public GameObject gameOver;

    private void Awake() {
        baseMovementSpeed = 10.0f;
        currentMovementSpeed = baseMovementSpeed;

        currentTimer = 0.0f;
        iFrameTimer = 1.5f;
        canBeHurt = true;

        maxHealth = 100f;
        myHealth = maxHealth;
        healthbar.value = myHealth;

        lightningBoltsPickup = false;
        drillsPickup = false;
        batteriesPickup = false;
        intervalHealth = -100.0f;

        rb = GetComponent<Rigidbody2D>();
        myRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        scoreDisplay = scoreText.GetComponent<Text>();
    }

    private void Update() {
        if (!canBeHurt) {
            endIframe();
        }

        if(myHealth <= 0) {
            gameOver.SetActive(true);
            Destroy(this.gameObject);
        }
        else
        {
            healthbar.value = myHealth / maxHealth;
        }

        pickupEffects();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.MovePosition(rb.position + movement * currentMovementSpeed * Time.fixedDeltaTime);

        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    private void LateUpdate() {
        scoreDisplay.text = "SCORE: " + playerScore.ToString();
    }

    public void startIFrames() {
        canBeHurt = false;
    }

    private void endIframe() {
        currentTimer += Time.deltaTime;
        if (currentTimer >= iFrameTimer) {
            myRenderer.enabled = true;
            canBeHurt = true;
            currentTimer = 0.0f;
        }
        else {
            if (myRenderer.enabled) {
                myRenderer.enabled = false;
            }
            else {
                myRenderer.enabled = true;
            }
        }
    }

    private void pickupEffects() {
        if (lightningBoltsPickup) { //Speed the player up for a time
            timeSinceLastLightningBoltsPickup += Time.deltaTime;
            if (timeSinceLastLightningBoltsPickup >= 15.0f) {
                lightningBoltsPickup = false;
                timeSinceLastLightningBoltsPickup = 0.0f;
                currentMovementSpeed = baseMovementSpeed;
            }
            else {
                currentMovementSpeed = 20.0f;
            }
        }

        if (batteriesPickup) { //Health the player over time            
            timeSinceLastBatteriesPickup += Time.deltaTime;
            if (timeSinceLastBatteriesPickup >= 6.0f) {
                batteriesPickup = false;
                timeSinceLastBatteriesPickup = 0.0f;
                intervalHealth = -100.0f;
            }
            else {
                if (Mathf.Floor(timeSinceLastBatteriesPickup) != intervalHealth) { //This is a thing I wrote...
                    intervalHealth = Mathf.Floor(timeSinceLastBatteriesPickup);
                    if( myHealth < 100) {
                        myHealth += 5;
                    }
                }
            }
        }

        if (drillsPickup) { //Fire an electron beam
            timeSinceLastDrillsPickup += Time.deltaTime;
            if (timeSinceLastDrillsPickup >= 3.0f) {
                drillsPickup = false;
                timeSinceLastDrillsPickup = 0.0f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(string.Compare("Enemy", collision.gameObject.transform.tag) == 0 && canBeHurt) {
            startIFrames();
            myHealth -= 20f;
            healthbar.value = myHealth / maxHealth;
        }
    }
}
