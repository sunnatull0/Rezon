using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private ParticleSystem _wallHitEffect;
    [SerializeField] private Gradient[] _gradients;
    private TrailRenderer _trailRenderer;
    private AudioEffects _audioEffects;

    private void Start()
    {
        _trailRenderer = GetComponent<TrailRenderer>();
        _audioEffects = FindObjectOfType<AudioEffects>();

        _trailRenderer.colorGradient = _gradients[Random.Range(0, _gradients.Length)];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Head"))
        {
            EnemyHealth enemyHealth = collision.transform.root.GetComponent<EnemyHealth>();
            enemyHealth.Damage(1f);
            if (enemyHealth.Health > 0f)
                _audioEffects.HitSound();
            else
                _audioEffects.DeadSound();
        }
        else
        {
            Instantiate(_wallHitEffect, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }
}
