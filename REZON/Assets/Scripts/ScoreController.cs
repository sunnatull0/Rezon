using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [HideInInspector] public float Score;
    [SerializeField] private float _record;
    [SerializeField] private Text _recordText;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _bulletText;
    [SerializeField] private Shooting _shootingScript;

    private void Start()
    {
        _record = PlayerPrefs.GetFloat("Record");
    }

    private void Update()
    {
        _recordText.text = _record.ToString("F0");
        _scoreText.text = Score.ToString("F0");
        _bulletText.text = _shootingScript.Bullets.ToString();

        if (Score > _record)
        {
            PlayerPrefs.SetFloat("Record", Score);
        }
    }

    public void AddScore(float amount)
    {
        Score += amount;
    }
}
