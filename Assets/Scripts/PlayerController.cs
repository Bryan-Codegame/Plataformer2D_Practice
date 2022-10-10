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

    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;
    
    private Rigidbody2D _rb;
    
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && isGround())
        {
            _rb.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
        }

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
}
