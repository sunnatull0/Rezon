using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private ScoreController _scoreController;
    [SerializeField] private GameObject[] _enemyPrefab;
    [SerializeField] private Transform[] _spawnPoints;

    [Header("COROUTINE WAIT TIMES")]
    [SerializeField] private float _easyLevelWaiting;
    [SerializeField] private float[] _midLevelWaiting;
    [SerializeField] private float[] _hardLevelWaiting;
    [SerializeField] private float[] _extremeLevelWaiting;

    [Header("MOVE TO LEVEL SCORES")]
    [SerializeField] private float _scoreToMidLevel;
    [SerializeField] private float _scoreToHardLevel;
    [SerializeField] private float _scoreToExtremeLevel;

    private Coroutine _currentCoroutine;

    private bool _isDone1 = false;
    private bool _isDone2 = false;
    private bool _isDone3 = false;

    private void Start()
    {
        _currentCoroutine = StartCoroutine(EnemySpawningEasy());
    }

    private void Update()
    {
        if (_scoreController.Score >= _scoreToMidLevel && !_isDone1)
        {
            StartMidLevel();
            _isDone1 = true;
        }
        else if (_scoreController.Score >= _scoreToHardLevel && !_isDone2)
        {
            StartHardLevel();
            _isDone2 = true;
        }
        else if (_scoreController.Score >= _scoreToExtremeLevel && !_isDone3)
        {
            StartExtremeLevel();
            _isDone3 = true;
        }
    }

    private void StartMidLevel()
    {
        StopCoroutine(_currentCoroutine);
        _currentCoroutine = StartCoroutine(EnemySpawningMid());
    }

    private void StartHardLevel()
    {
        StopCoroutine(_currentCoroutine);
        _currentCoroutine = StartCoroutine(EnemySpawningHard());
    }

    private void StartExtremeLevel()
    {
        StopCoroutine(_currentCoroutine);
        _currentCoroutine = StartCoroutine(EnemySpawningExtreme());
    }

    private IEnumerator EnemySpawningEasy()
    {
        while (true)
        {
            Instantiate(_enemyPrefab[0], _spawnPoints[Random.Range(0, _spawnPoints.Length)].position, Quaternion.identity);
            yield return new WaitForSeconds(_easyLevelWaiting);
        }
    }

    private IEnumerator EnemySpawningMid()
    {
        while (true)
        {
            Instantiate(_enemyPrefab[Random.Range(0, 2)], _spawnPoints[Random.Range(0, _spawnPoints.Length)].position, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(_midLevelWaiting[0], _midLevelWaiting[1]));
        }
    }

    private IEnumerator EnemySpawningHard()
    {
        while (true)
        {
            Instantiate(_enemyPrefab[Random.Range(1, 3)], _spawnPoints[Random.Range(0, _spawnPoints.Length)].position, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(_hardLevelWaiting[0], _hardLevelWaiting[1]));
        }
    }

    private IEnumerator EnemySpawningExtreme()
    {
        while (true)
        {
            Instantiate(_enemyPrefab[Random.Range(2, 4)], _spawnPoints[Random.Range(0, _spawnPoints.Length)].position, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(_extremeLevelWaiting[0], _extremeLevelWaiting[1]));
        }
    }
}
