using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField] private Shooting _shootingScript;
    [SerializeField] private MouseLook _mouseLookScript;
    [SerializeField] private GameOverScript _gameOverScript;
    [SerializeField] private TutorialScript _tutorialScript;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private GameObject _pausePanel;
    private bool _isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_gameOverScript.IsPlaying && !_tutorialScript.TutPlaying)
            Pause();
    }

    public void Pause()
    {
        _audio.Play();
        if (!_isPaused)
        {
            _shootingScript.enabled = false;
            _mouseLookScript.enabled = false;
            _pausePanel.SetActive(true);
            _isPaused = true;
            Time.timeScale = 0;
        }
        else
        {
            _shootingScript.enabled = true;
            _mouseLookScript.enabled = true;
            _pausePanel.SetActive(false);
            _isPaused = false;
            Time.timeScale = 1;
        }
    }
}
