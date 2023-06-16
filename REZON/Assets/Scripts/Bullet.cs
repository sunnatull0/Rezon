using UnityEngine;

public class Bullet : MonoBehaviour
{   
    private AudioEffects _audioEffects;

    private void Start()
    {
        _audioEffects = FindObjectOfType<AudioEffects>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Head"))
        {
            EnemyHealth enemyHealth = collision.transform.root.GetComponent<EnemyHealth>();
            enemyHealth.Damage(1f);
            if (enemyHealth.Health > 0f)
            {
                _audioEffects.HitSound();
            }
            else
            {
                _audioEffects.DeadSound();
            }
        }
        Destroy(gameObject);
    }
}
