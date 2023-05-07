using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float radius;
    [SerializeField] private Transform groundPosition;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb;
    private float horInput;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horInput = Input.GetAxisRaw("Horizontal");
        isGrounded = Physics2D.OverlapCircle(groundPosition.position, radius, groundLayer);

        Jump();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horInput * speed * Time.fixedDeltaTime, rb.velocity.y); //MOVE
    }


    void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded)
        {
            rb.AddForce(transform.up * jumpForce);
        }
    }
    
    void Flip()
    {
        if(horInput > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 0f, transform.rotation.z));
        } 
        else if (horInput < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 180f, transform.rotation.z));
        }
    }
}
