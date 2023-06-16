using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private Transform _headPosition;
    
    public float Health;
    private ScoreController _scoreController;
    private Effects _effects;

    private void Start()
    {
        _scoreController = FindObjectOfType<ScoreController>();
        _effects = FindObjectOfType<Effects>();
    }

    private void Update()
    {
        if (Health <= 0f && gameObject.tag == "one")
        {
            Death(1f);
        }
        else if (Health <= 0f && gameObject.tag == "two")
        {
            Death(2f);
        }
        else if (Health <= 0f && gameObject.tag == "three")
        {
            Death(3f);
        }
        else if (Health <= 0f && gameObject.tag == "four")
        {
            Death(4f);
        }
    }

    public void Damage(float amount)
    {
        Health -= amount;
    }

    private void Death(float scoreToAdd)
    {
        _scoreController.AddScore(scoreToAdd);
        _effects.EffectPlay(_headPosition.position);
        Destroy(gameObject);
    }
}
