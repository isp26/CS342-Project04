using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;

    private void Awake() {
        Destroy(this.gameObject, 1.0f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.3f);
        Destroy(gameObject);
    }

}
