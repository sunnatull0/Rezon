using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletDeathPos;
    [SerializeField] private float bulletDeathPos2;
    
    private AudioEffects audioEffects;

    private void Start()
    {
        audioEffects = FindObjectOfType<AudioEffects>();
    }

    void Update()
    {
        DeadBullet();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Head"))
        {
            EnemyHealth enemyHealth = collision.transform.root.GetComponent<EnemyHealth>();
            //EnemyHealth enemyHealths = collision.transform.root.GetComponent<EnemyHealth>();
            enemyHealth.Damage(1f);
            if (enemyHealth.health > 0f)
            {
                audioEffects.HitSound();
            }
            else
            {
                audioEffects.DeadSound();
            }
        }
        Destroy(gameObject);
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Head"))
        {
            EnemyHealth enemyHealth = collision.transform.parent.GetComponent<EnemyHealth>();
            enemyHealth.Damage(1f);
            if (enemyHealth.health > 0f)
            {
                audioEffects.HitSound();
            }
            else
            {
                audioEffects.DeadSound();
            }
        }
        Destroy(gameObject);
    }



    void DeadBullet()
    {
        if (transform.position.x > bulletDeathPos || transform.position.y > bulletDeathPos)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x < bulletDeathPos2 || transform.position.y < bulletDeathPos2)
        {
            Destroy(gameObject);
        }
    }
}
