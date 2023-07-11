using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private Text _recordText;
    [SerializeField] private AudioSource _audioSource;
    private bool _isMuted = false;

    private void Start()
    {
        _recordText.text = PlayerPrefs.GetFloat("Record").ToString("F0");
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
