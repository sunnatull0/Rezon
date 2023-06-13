using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] EnemySpeed enemycontrol;
    [SerializeField] Transform headPos;
    ScoreController scoreController;
    Effects effects;

    private Rigidbody2D enemyRb;
    private bool isDone = false;

    void Start()
    {
        scoreController = FindObjectOfType<ScoreController>();
        effects = FindObjectOfType<Effects>();
        enemyRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Flip();
    }

    void FixedUpdate()
    {
        enemyRb.velocity = new Vector2(enemycontrol.enemySpeed * Time.deltaTime, enemyRb.velocity.y);
    }

    void Flip()
    {
        if (transform.position.x > 0f && !isDone)
        {
            enemycontrol.enemySpeed = -enemycontrol.enemySpeed;
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            isDone = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Finish"))
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        //Debug.Log("End");
    }

    public void DeathEffects(float scoretoadd)
    {
        scoreController.AddScore(scoretoadd);
        effects.EffectPlay(headPos.position);
        Destroy(gameObject);
    }

}
