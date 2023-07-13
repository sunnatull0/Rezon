using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    [SerializeField] private Shooting _shootingScript;
    [SerializeField] private GameObject _tutorialPanel;
    [SerializeField] private string _shownKey;
    [HideInInspector] public bool TutPlaying = false;

    private void Start()
    {
        if (!PlayerPrefs.HasKey(_shownKey))
        {
            TutPlaying = true;
            _tutorialPanel.SetActive(true);
            PlayerPrefs.SetInt(_shownKey, 1);
            _shootingScript.enabled = false;
            Time.timeScale = 0;
        }
        else
        {
            _tutorialPanel.SetActive(false);
        }
    }

    public void EndTutorial()
    {
        TutPlaying = false;
        _shootingScript.enabled = true;
        Time.timeScale = 1;
    }
}
