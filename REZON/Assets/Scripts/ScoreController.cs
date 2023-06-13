using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreController : MonoBehaviour
{
    [HideInInspector] public float score;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text bulletText;
    [SerializeField] Shooting shootingScript;
    [SerializeField] float scoreSpeed;

    void Update()
    {
        scoreText.text = score.ToString("F0");
        bulletText.text = shootingScript.Bullets.ToString();
    }

    public void AddScore(float amount)
    {
        score += amount;
    }
}
