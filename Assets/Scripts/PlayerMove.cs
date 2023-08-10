using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//AGREGAR UN GameObjet VACIO CON COLLIDER DENTRO DEL PLAYER, A LOS PIES

public class PlayerMove : MonoBehaviour
{
    public float _runSpeed = 2;
    public float _jumpSpeed = 3;
    Rigidbody2D _rb2D;

    public bool _betterJump = false;
    public float _fallMultiplier = 0.5f;
    public float _lowJumpMultiplier = 1f;

    public SpriteRenderer _spriteRenderer;
    public Animator _anim;

    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(Input.GetAxisRaw("Horizontal") > 0f)
        {
            _rb2D.velocity = new Vector2 (_runSpeed, _rb2D.velocity.y);
            _spriteRenderer.flipX = false;
            _anim.SetBool("Run",true);
        }
        else if(Input.GetAxisRaw("Horizontal") < 0f)
        {
            _rb2D.velocity = new Vector2 (-_runSpeed, _rb2D.velocity.y);
            _spriteRenderer.flipX = true;
            _anim.SetBool("Run",true);
        }
        else
        {
            _rb2D.velocity = new Vector2(0, _rb2D.velocity.y);
            _anim.SetBool("Run",false);
        }

        if(Input.GetKey("space") && CheckGround._isGrounded)
        {
            _rb2D.velocity = new Vector2(_rb2D.velocity.x, _jumpSpeed);

        }

        if(CheckGround._isGrounded==false)
        {
            _anim.SetBool("Jump", true);
            _anim.SetBool("Run", false);
        }
        if(CheckGround._isGrounded==true)
        {
            _anim.SetBool("Jump", false);
        }

        if(_betterJump)
        {
            if(_rb2D.velocity.y < 0)
            {
            _rb2D.velocity += Vector2.up * Physics2D.gravity.y * (_fallMultiplier) * Time.deltaTime;
            }

            if(_rb2D.velocity.y > 0 && !Input.GetKey("space"))
            {
            _rb2D.velocity += Vector2.up * Physics2D.gravity.y * (_lowJumpMultiplier) * Time.deltaTime;
            }
        }
    }
}
