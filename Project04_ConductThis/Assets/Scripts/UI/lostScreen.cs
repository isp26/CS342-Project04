using UnityEngine;
using UnityEngine.SceneManagement;

public class lostScreen : MonoBehaviour
{
    public void restLevel() {
        SceneManager.LoadScene("SampleScene");
    }

    public void quitGame() {
        Application.Quit();
    }
}
