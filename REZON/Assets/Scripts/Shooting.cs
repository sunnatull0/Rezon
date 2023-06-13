using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [HideInInspector] public int Bullets;

    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private AudioClip _shootSound;
    [SerializeField] private Transform _bulletPosition;
    [SerializeField] private int _startAmmo;
    [SerializeField] private float _bulletspeed;
    [SerializeField] private float _reloadTime;

    private AudioSource _audioSource;
    private bool _canShoot = true;

    private void Start()
    {
        Bullets = _startAmmo;
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Shoot();

        // Reloading
        if (Input.GetKeyDown(KeyCode.R) && Bullets != _startAmmo && _canShoot)
            StartCoroutine(Reloading());
    }

    private void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && _canShoot)
        {
            Bullets--;

            // Bullet
            GameObject bullet = Instantiate(_bulletPrefab, _bulletPosition.position, _bulletPosition.rotation);
            Rigidbody2D rbbullet = bullet.GetComponent<Rigidbody2D>();
            rbbullet.AddForce(transform.right * _bulletspeed, ForceMode2D.Impulse);

            // Audio
            _audioSource.pitch = Random.Range(0.95f, 1.3f);
            _audioSource.PlayOneShot(_shootSound);

            // AutoReloading
            if (Bullets <= 0)
                StartCoroutine(Reloading());
        }
    }

    private IEnumerator Reloading()
    {
        _canShoot = false;
        yield return new WaitForSeconds(_reloadTime);
        _canShoot = true;
        Bullets = _startAmmo;
    }

}
