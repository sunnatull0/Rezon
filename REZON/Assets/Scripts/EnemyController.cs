using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private ScoreController scoreController;
    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float waitSeconds;
    [SerializeField] private float[] waitSecondsMid;
    [SerializeField] private float[] waitSecondsHard;
    [SerializeField] private float[] waitSecondsHard2;
    [SerializeField] private float MidLevel;
    [SerializeField] private float HardLevel;
    [SerializeField] private float Hard2Level;

    Coroutine easy;
    Coroutine mid;
    Coroutine hard;
    Coroutine hard2;

    bool isDone1 = false;
    bool isDone2 = false;
    bool isDone3 = false;

    void Start()
    {
        easy = StartCoroutine(EnemySpawningEasy());
    }

    // Update is called once per frame
    void Update()
    {
        if(scoreController.score >= MidLevel && !isDone1)
        {
            StopCoroutine(easy);
            mid = StartCoroutine(EnemySpawningMid());
            isDone1 = true;
        }
        
        if(scoreController.score >= HardLevel && !isDone2)
        {
            StopCoroutine(mid);
            hard = StartCoroutine(EnemySpawningHard());
            isDone2 = true;
        }
        
        if(scoreController.score >= Hard2Level && !isDone3)
        {
            StopCoroutine(hard);
            hard2 = StartCoroutine(EnemySpawningHard2());
            isDone3 = true;
        }
    }

    IEnumerator EnemySpawningEasy()
    {
        while (true)
        {
            Instantiate(enemyPrefab[0], spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
            yield return new WaitForSeconds(waitSeconds);
        }
    }

    IEnumerator EnemySpawningMid()
    {
        while (true)
        {
            Instantiate(enemyPrefab[Random.Range(0, 2)], spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(waitSecondsMid[0], waitSecondsMid[1]));
        }
    }
    
    IEnumerator EnemySpawningHard()
    {
        while (true)
        {
            Instantiate(enemyPrefab[Random.Range(1, 3)], spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(waitSecondsHard[0], waitSecondsHard[1]));
        }
    }

    IEnumerator EnemySpawningHard2()
    {
        while (true)
        {
            Instantiate(enemyPrefab[Random.Range(2, 4)], spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(waitSecondsHard2[0], waitSecondsHard2[1]));
        }
    }
}
