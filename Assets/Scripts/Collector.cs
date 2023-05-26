using UnityEngine;

public class Collector : MonoBehaviour
{
    private const string ENEMY_TAG = "Enemy";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ENEMY_TAG))
            Destroy(collision.gameObject);
    }
}
