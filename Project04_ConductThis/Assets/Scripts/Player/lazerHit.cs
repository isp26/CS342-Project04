using UnityEngine;

public class lazerHit : MonoBehaviour
{
    private void Awake() {
        Destroy(this.gameObject, 0.2f);
    }
}
