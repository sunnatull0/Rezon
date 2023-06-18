using System.Collections;
using UnityEngine;
using Cinemachine;

public class Shooting : MonoBehaviour
{
    [HideInInspector] public int Bullets;

    [SerializeField] private AudioClip _shootSound;
    [SerializeField] private AudioClip _noAmmoSound;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private ParticleSystem _muzzleFlash;
    [SerializeField] private Transform _bulletPosition;
    [SerializeField] private int _startAmmo;
    [SerializeField] private float _bulletspeed;
    [SerializeField] private float _reloadTime;

    private CinemachineImpulseSource _impulse;
    private AudioSource _audioSource;
    private bool _hasAmmo;
    private bool _isReloading = false;

    private void Start()
    {
        Bullets = _startAmmo;
        _impulse = GetComponent<CinemachineImpulseSource>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Shoot();

        // Ammo Check
        _hasAmmo = Bullets > 0;

        // Reloading
        if (Input.GetKeyDown(KeyCode.R) && !_isReloading && Bullets != _startAmmo)
            StartCoroutine(Reloading());
    }

    private void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && !_isReloading && _hasAmmo)
        {
            Bullets--;

            // ScreenShake
            _impulse.GenerateImpulse(3f);

            // Bullet
            GameObject bullet = Instantiate(_bulletPrefab, _bulletPosition.position, _bulletPosition.rotation);
            Rigidbody2D rbbullet = bullet.GetComponent<Rigidbody2D>();
            rbbullet.AddForce(transform.right * _bulletspeed, ForceMode2D.Impulse);

            // Audio
            _audioSource.pitch = Random.Range(0.95f, 1.3f);
            _audioSource.PlayOneShot(_shootSound);

            // MuzzleFlash
            _muzzleFlash.Play();
        }
        else if (Input.GetButtonDown("Fire1") && !_isReloading && !_hasAmmo)
        {
            _audioSource.pitch = 1f;
            _audioSource.PlayOneShot(_noAmmoSound);
        }
    }

    private IEnumerator Reloading()
    {
        //_canShoot = false;
        _isReloading = true;
        yield return new WaitForSeconds(_reloadTime);
        //_canShoot = true;
        _isReloading = false;
        Bullets = _startAmmo;
    }
}