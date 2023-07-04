using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private LevelTransition _levelTransition;
    [SerializeField] private AudioSource _audioSource;
    private bool _isMuted = false;
    public void StartButton()
    {
        _levelTransition.LoadNextLevel(1);
    }

    public void MusicButton()
    {
        if (!_isMuted)
        {
            _audioSource.mute = true;
            _isMuted = true;
        }
        else
        {
            _audioSource.mute = false;
            _isMuted = false;
        }
    }
}
