using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    private void Update() {
        if (Input.GetKey(KeyCode.Space)) {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
