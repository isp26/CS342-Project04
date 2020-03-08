using Pathfinding;
using UnityEngine;

public class AIController : MonoBehaviour
{
    private AIPath path;
    private AIDestinationSetter direction;
    private GameObject patrolLocation;
    private GameObject player;
    private PlayerController playerScript;

    private bool waitStat;
    private bool patrolStat;
    private bool huntStat;
    private float currentWaitTimer;
    private float maximumWaitTime;

    public GameObject patrolObject;
    public float myHealth;
    public float mySpeed;
    public string AI_Type;
    public bool slowed;
    

    private void Awake() {
        path = this.gameObject.GetComponent<AIPath>();
        direction = this.gameObject.GetComponent<AIDestinationSetter>();
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        playerScript = player.GetComponent<PlayerController>();

        if (string.Compare("Normal", AI_Type) == 0) {
            mySpeed = Random.Range(5.0f, 15.0f);
        }
        else {
            mySpeed = Random.Range(15.0f, 25.0f);
        }

        waitStat = true;
        patrolStat = false;
        huntStat = false;
        maximumWaitTime = 3.0f;
        currentWaitTimer = 0.0f;

        nextPatrolStat();
    }

    private void Update() {
        path.maxSpeed = mySpeed;

        if (myHealth <= 0.0f ) {
            if(string.Compare("Normal", AI_Type) == 0) {
                gameController.numberOfNormalAI -= 1;
                playerScript.playerScore += 50;
                
            }
            else {
                gameController.numberOfHardAI -= 1;
                playerScript.playerScore += 100;
            }
            Destroy(this.gameObject);
        }

        if (slowed) {
            path.maxSpeed = mySpeed / 2;
            slowed = false; //This is what happens when you don't have a UML
        }

        if(patrolLocation != null) {
            if (this.gameObject.transform.position == patrolLocation.transform.position && !huntStat) {
                huntStat = false;
                patrolStat = false;
                waitStat = true;
            }
        }

        if (huntStat) {
            if (player != null) {
                direction.target = player.transform;
            }
            else {
                huntStat = false;
                patrolStat = true;
                waitStat = false;
            }
        }
        else if (patrolStat) {
            if (patrolLocation != null) {
                direction.target = patrolLocation.transform;
            }
            else {
                nextPatrolStat();
                direction.target = patrolLocation.transform;
            }
        }
        else if (waitStat) {
            waiting();
        }
        else {
            Debug.Log("AI error on stat controller");
        }
    }

    private void nextPatrolStat() {
        float xLocation = Random.Range(-19.0f, 19.0f);
        float yLocation = Random.Range(-19.0f, 19.0f);
        Vector3 newLocation = new Vector3(xLocation, yLocation, 0.0f);

        patrolLocation = Instantiate(patrolObject, newLocation, this.gameObject.transform.rotation);
    }

    private void waiting() {
        currentWaitTimer += Time.deltaTime;
        if(maximumWaitTime <= currentWaitTimer) {
            currentWaitTimer = 0.0f;
            huntStat = false;
            patrolStat = true;
            waitStat = false;

            Destroy(patrolLocation);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (string.Compare("Bullet", collision.transform.tag) == 0) {
            myHealth -= 30.0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(string.Compare("Player", collision.transform.tag) == 0) {
            currentWaitTimer = 0.0f;
            huntStat = true;
            patrolStat = false;
            waitStat = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (string.Compare("Player", collision.transform.tag) == 0) {
            currentWaitTimer = 0.0f;
            huntStat = false;
            patrolStat = true;
            waitStat = false;
        }
    }
}
