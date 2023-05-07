using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject bullet_prefab;
    [SerializeField] private GameObject middle;
    [SerializeField] private GameObject boss;
    [SerializeField] private SpriteRenderer gunSprite;
    [SerializeField] private AudioClip shootSound;
    [SerializeField] private Transform bullet_pos;
    [SerializeField] private int startBullets;
    [SerializeField] private float bulletspeed;
    [SerializeField] private float reloadTime;

    private AudioSource audioSource;
    private Camera camera;
    private Vector2 mousePos;
    private bool canShoot = true;
    private bool isRight = true;
    [HideInInspector] public int bullets;

    void Start()
    {
        bullets = startBullets;
        audioSource = GetComponent<AudioSource>();
        camera = Camera.main;
    }

    void Update()
    {
        //MouseLook
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        middle.transform.right = mousePos - new Vector2(middle.transform.position.x, middle.transform.position.y);

        Rotations();
        Shoot();

        //Reloading
        if (Input.GetKeyDown(KeyCode.R) && bullets != startBullets && canShoot)
        {
            StartCoroutine(Reloading());
        }
    }

    void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            audioSource.pitch = Random.Range(0.95f, 1.3f);
            audioSource.PlayOneShot(shootSound);

            GameObject bullet = Instantiate(bullet_prefab, bullet_pos.position, bullet_pos.rotation);
            Rigidbody2D rbbullet = bullet.GetComponent<Rigidbody2D>();
            rbbullet.AddForce(transform.right * bulletspeed, ForceMode2D.Impulse);

            bullets--;

            if (bullets <= 0)
            {
                StartCoroutine(Reloading());
            }
        }
    }

    void Rotations()
    {
        if (middle.transform.eulerAngles.z > 90f && middle.transform.eulerAngles.z < 270f && isRight)
        {
            gunSprite.flipY = true;
            boss.transform.Rotate(0, 180, 0);
            isRight = false;
        }
        else if (middle.transform.eulerAngles.z < 90f && !isRight || middle.transform.eulerAngles.z > 270f && !isRight)
        {
            gunSprite.flipY = false;
            boss.transform.Rotate(0, -180, 0);
            isRight = true;
        }
    }

    IEnumerator Reloading()
    {
        canShoot = false;
        yield return new WaitForSeconds(reloadTime);
        canShoot = true;
        bullets = startBullets;
    }

}
