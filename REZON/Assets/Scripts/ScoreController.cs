using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    [HideInInspector] public float Score;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _bulletText;
    [SerializeField] private Shooting _shootingScript;

    private void Update()
    {
        _scoreText.text = Score.ToString("F0");
        _bulletText.text = _shootingScript.Bullets.ToString();
    }

    public void AddScore(float amount)
    {
        Score += amount;
    }
}
