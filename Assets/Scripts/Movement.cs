using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    PlayerInput _input;

    public float speed;
    public float force;

    public bool IsOnGround { get; private set; }

    Rigidbody2D _rigidbody2D;    
    Animator _animator;

    Quaternion quaternion0 = Quaternion.Euler(0f, 0f, 0f);
    Quaternion quaternion180 = Quaternion.Euler(0f, 180f, 0f);

    private void Awake()
    {
        _input = new PlayerInput();
    }

    private void OnEnable()
    {
        _input.Enable();
        _input.Player.Jump.performed += context => Jump();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();        
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector2 inputVector =_input.Player.Move.ReadValue<Vector2>();

        if (inputVector != Vector2.zero)
        {
            Move(inputVector);
            _animator.SetBool("run", true);
        }
        else
        {
            _animator.SetBool("run", false);
        }
    }

    void Jump()
    {
        if (!IsOnGround)
            return;

        SetIsOnGround(false);
        _rigidbody2D.AddForce(Vector2.up * force);
    }

    public void SetIsOnGround(bool _isOnGround)
    {        
        IsOnGround = _isOnGround;
        _animator.SetBool("jump", ! _isOnGround);
    }

    private void Move(Vector2 _inputVector)
    {
        float tempSpeed = _inputVector.x;        

        if(tempSpeed < 0f)
        {
            transform.rotation = quaternion180;
        }
        else if (tempSpeed > 0f)
        {
            transform.rotation = quaternion0;
        }

        if (tempSpeed < 0f)
            tempSpeed *= -1f;

        transform.Translate(Vector2.right * tempSpeed * Time.deltaTime * speed, Space.Self);
    }
}