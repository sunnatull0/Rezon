using UnityEngine;

public class AudioEffects : MonoBehaviour
{
    [SerializeField] private AudioClip _gameOverSound;
    [SerializeField] private AudioClip _hitSound;
    [SerializeField] private AudioClip[] _deathSounds;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void HitSound()
    {
        _audioSource.pitch = Random.Range(0.8f, 1.2f);
        _audioSource.PlayOneShot(_hitSound);
    }

    public void DeadSound()
    {
        _audioSource.pitch = Random.Range(0.7f, 1.1f);
        _audioSource.PlayOneShot(_deathSounds[Random.Range(0, _deathSounds.Length)]);
    }

    public void GameOverSoundPlay()
    {
        _audioSource.pitch = 0.7f;
        _audioSource.PlayOneShot(_gameOverSound);
    }

}
