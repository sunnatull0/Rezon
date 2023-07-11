using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameOverScript _gameOverScript;
    private EnemySpeed _enemySpeedScript;
    private Rigidbody2D _enemyRb;

    private bool _isDone = false;
    private bool _isDone1 = false;

    private void Start()
    {
        _gameOverScript = FindObjectOfType<GameOverScript>();
        _enemySpeedScript = GetComponent<EnemySpeed>();
        _enemyRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Flip();
    }

    private void FixedUpdate()
    {
        _enemyRb.velocity = new Vector2(_enemySpeedScript.enemySpeed * Time.deltaTime, _enemyRb.velocity.y);
    }

    private void Flip()
    {
        if (transform.position.x > 0f && !_isDone)
        {
            _enemySpeedScript.enemySpeed = -_enemySpeedScript.enemySpeed;
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            _isDone = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Finish")) && !_isDone1)
        {
            _gameOverScript.GameOver();
            _isDone1 = true;
        }
    }
}
