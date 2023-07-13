using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private Text _recordText;
    [SerializeField] private AudioSource _audioSource;
    private string _music = "Music";

    private void Start()
    {
        _recordText.text = PlayerPrefs.GetFloat("Record").ToString("F0");
        if (!PlayerPrefs.HasKey(_music))
            PlayerPrefs.SetString(_music, "Unmuted");

        if (PlayerPrefs.GetString(_music) == "Unmuted")
            _audioSource.Play();
    }

    public void MusicButton()
    {
        if (PlayerPrefs.GetString(_music) == "Unmuted")
        {
            PlayerPrefs.SetString(_music, "Muted");
            _audioSource.mute = true;
        }
        else
        {
            PlayerPrefs.SetString(_music, "Unmuted");
            _audioSource.Play();
            _audioSource.mute = false;
        }
    }
}
