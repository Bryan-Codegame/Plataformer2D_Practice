using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10;
    public float jumpForce = 5;
    public bool isOnGround = true;

    private bool isFacingRight = true;

    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;
    
    private Rigidbody2D _rb;
    private Animator _animator;
    
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        _animator.SetFloat("HorizontalAnim", Mathf.Abs(horizontalInput));

        if (Input.GetKeyDown(KeyCode.Space) && isGround())
        {
            _rb.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
        }
        
        Flip();

    }
    
    void FixedUpdate()
    {
        _rb.velocity = new Vector2(speed * horizontalInput, _rb.velocity.y);
        //_rb.AddForce(new Vector2(speed*horizontalInput, transform.position.y), ForceMode2D.Force);
    }
    
    bool isGround()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, 0.3f, _groundLayer);
    }

    void Flip()
    {
        if (horizontalInput > 0 && !isFacingRight || horizontalInput < 0 && isFacingRight)
        {
            isFacingRight = !isFacingRight;
            Vector2 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
