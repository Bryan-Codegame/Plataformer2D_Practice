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

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            _rb.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
            isOnGround = false;
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        isOnGround = true;
    }
    
    void FixedUpdate()
    {
        
        _rb.velocity = new Vector2(speed * horizontalInput, _rb.velocity.y);
        //_rb.AddForce(new Vector2(speed*horizontalInput, transform.position.y), ForceMode2D.Force);
    }
}
