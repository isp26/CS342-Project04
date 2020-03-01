using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float myHealth;
    public float maxHealth;
    public bool canBeHurt;
    public int playerScore;
    public Slider healthbar;

    private Rigidbody2D rb;
    private SpriteRenderer myRenderer;
    private float currentTimer;
    private float iFrameTimer;

    private void Awake() {
        currentTimer = 0.0f;
        iFrameTimer = 1.5f;
        canBeHurt = true;

        maxHealth = 100f;
        myHealth = maxHealth;
        healthbar.value = myHealth;

        rb = GetComponent<Rigidbody2D>();
        myRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update() {
        if (!canBeHurt) {
            endIframe();
        }

        if(myHealth <= 0) {
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.AddForce(movement * speed);
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

    private void OnCollisionEnter2D(Collision2D collision) {
        if(string.Compare("Enemy", collision.gameObject.transform.tag) == 0 && canBeHurt) {
            startIFrames();
            myHealth -= 20f;
            healthbar.value = myHealth / maxHealth;
            Debug.Log(healthbar.value);
        }
    }
}
