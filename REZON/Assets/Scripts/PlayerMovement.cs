using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform _groundPosition;
    [SerializeField] private LayerMask _groundLayer;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _radius;

    private Rigidbody2D _rb;
    private float _horInput;
    private bool _isGrounded;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _horInput = Input.GetAxisRaw("Horizontal");
        _isGrounded = Physics2D.OverlapCircle(_groundPosition.position, _radius, _groundLayer);

        Jump();
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_horInput * _speed * Time.fixedDeltaTime, _rb.velocity.y);
    }

    private void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && _isGrounded)
            _rb.AddForce(transform.up * _jumpForce);
    }
}
