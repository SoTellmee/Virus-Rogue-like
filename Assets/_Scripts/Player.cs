using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _checkRaduis;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _jump = 3f;

    private bool _isGrounded;

   private void Initialize()
   {
       //character 
   }


    private void FixedUpdate()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position,_checkRaduis, _whatIsGround);

        Move();  
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            Jump();
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(horizontal, 0);

        if (movement.magnitude > 0)
        {
            _rigidbody.velocity = new Vector2(movement.x * _speed, _rigidbody.velocity.y);
        }
        AnimationMove();
    }

    private void Jump()
    {
        _rigidbody.velocity = Vector2.up * _jump;
    }

    private void AnimationMove()
    {

    }
}
