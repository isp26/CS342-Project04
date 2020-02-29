using UnityEngine;

public class gameController : MonoBehaviour
{
    public static int numberOfNormalAI;
    private int maxNumberOfNormalAI;
    private float lastNormalAIIncreaseScroe;

    public static int numberOfHardAI;
    private int maxNumberOfHardAI;
    private float lastHardAIIncreaseScroe;

    private GameObject player;
    private PlayerController playerScript;

    private int playerCurrentScore;

    public GameObject normalAI;
    public GameObject hardAI;

    private void Awake() {
        numberOfNormalAI = 6;
        numberOfHardAI = 0;
        maxNumberOfNormalAI = 6;
        maxNumberOfHardAI = 0;

        lastNormalAIIncreaseScroe = 0.0f;
        lastHardAIIncreaseScroe = 0.0f;

        player = GameObject.FindGameObjectsWithTag("Player")[0];
        playerScript = player.GetComponent<PlayerController>();
        playerCurrentScore = playerScript.playerScore;
    }

    private void Start() {
        spawnStartingAI();
    }

    private void Update() {
        playerCurrentScore = playerScript.playerScore;
        if (playerScript.myHealth > 0.0f) {
            respawn();
            increaseAICount();
        }
    }

    private Vector3 pickASpawnLocation() {
        return new Vector3(Random.Range(-19.0f, 19.0f), Random.Range(-19.0f, 19.0f), 0.0f);
    }

    private void spawnStartingAI() {
        for (int i = 0; i < 6; ++i) {
            GameObject AI =  Instantiate(normalAI, pickASpawnLocation(), this.gameObject.transform.rotation);
            AI.GetComponent<AIController>().AI_Type = "Normal";
        }
    }

    private void respawn() {
        if (numberOfNormalAI < maxNumberOfNormalAI) {
            int dif = maxNumberOfNormalAI - numberOfNormalAI;
            for (int i = 0; i < dif; ++i) {
                GameObject AI = Instantiate(normalAI, pickASpawnLocation(), this.gameObject.transform.rotation);
                AI.GetComponent<AIController>().AI_Type = "Normal";
            }
            numberOfNormalAI += dif;
        }

        if (numberOfHardAI < maxNumberOfHardAI) {
            int dif = maxNumberOfHardAI - numberOfHardAI;
            for (int i = 0; i < dif; ++i) {
                GameObject AI = Instantiate(hardAI, pickASpawnLocation(), this.gameObject.transform.rotation);
                AI.GetComponent<AIController>().AI_Type = "Hard";
            }
            numberOfHardAI += dif;
        }
    }

    private void increaseAICount() {
        if ((playerCurrentScore - lastNormalAIIncreaseScroe) / 200 >= 1.0f) {
            lastNormalAIIncreaseScroe = playerCurrentScore;
            maxNumberOfNormalAI += 1;
        }

        if ((playerCurrentScore - lastHardAIIncreaseScroe) / 400 >= 1.0f) {
            lastHardAIIncreaseScroe = playerCurrentScore;
            maxNumberOfHardAI += 1;
        }
    }

}
