using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    [SerializeField] private LevelTransition _levelTransition;
    [SerializeField] private Shooting _shootingScript;
    [SerializeField] private AudioEffects _audioScript;
    [SerializeField] private GameObject _gameOverUI;

    [HideInInspector] public bool IsPlaying = false;

    public void GameOver()
    {
        IsPlaying = true;
        _audioScript.GameOverSoundPlay();
        _gameOverUI.SetActive(true);
        _shootingScript.enabled = false;
        Time.timeScale = 0;
    }
}
