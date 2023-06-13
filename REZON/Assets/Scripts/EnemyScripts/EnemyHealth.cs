using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] EnemyMovement enemyMovement;
    [SerializeField] public float health;

    private void Update()
    {
        if (health <= 0f && gameObject.tag == "one")
        {
            enemyMovement.DeathEffects(1f);
        }
        else if (health <= 0f && gameObject.tag == "two")
        {
            enemyMovement.DeathEffects(2f);
        }
        else if (health <= 0f && gameObject.tag == "three")
        {
            enemyMovement.DeathEffects(3f);
        }
        else if (health <= 0f && gameObject.tag == "four")
        {
            enemyMovement.DeathEffects(4f);
        }
    }

    public void Damage(float amount)
    {
        health -= amount;
    }
}
