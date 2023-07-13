using UnityEngine;

public class BackMusicScript : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    private string _music = "Music";
    void Start()
    {
        if (PlayerPrefs.GetString(_music) == "Muted")
            _audio.mute = true;
        else if (PlayerPrefs.GetString(_music) == "Unmuted")
            _audio.mute = false;
    }
}
