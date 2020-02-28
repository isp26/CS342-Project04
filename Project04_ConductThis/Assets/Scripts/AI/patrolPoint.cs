using UnityEngine;

public class patrolPoint : MonoBehaviour
{
    private void Awake() {
        Destroy(this.gameObject, 20.0f);
    }
}
