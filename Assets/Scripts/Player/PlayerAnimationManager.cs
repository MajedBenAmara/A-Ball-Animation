using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimationManager : MonoBehaviour
{
    private PlayerControl _playerControler;
    private Rigidbody2D _rb;
    private Animator _anim;
    private PlayerInput _playerInput;
    private InputAction _jumlpAction;
    private bool squishAnimationIsPlaying = false;

    private BallBounce _ballbounce;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerControler = GetComponent<PlayerControl>();
        _anim = GetComponent<Animator>();
        _playerInput = GetComponent<PlayerInput>();
        _ballbounce = GetComponent<BallBounce>();
        _jumlpAction = _playerInput.actions["Jump"];

        squishAnimationIsPlaying = false;
    }

    private void Update()
    {
        if(_playerControler.playSquish && _rb.velocity == Vector2.zero)
        {
            _anim.Play("Squish");

        }

        if (_playerControler.playSquash )
        {
            _anim.Play("Squash");
        }

        if (Mathf.Abs(_rb.velocity.y) >= 0.4f)
        {
            PlayBounce();
        }

        if (_rb.velocity.y == 0 && !_playerControler.playSquish)
        {
            _anim.Play("Idle");
        }

        /*        if (_anim.GetCurrentAnimatorStateInfo(0).IsTag("Squash"))
                {
                    squishAnimationIsPlaying = false;
                }
                else if (!squishAnimationIsPlaying)
                {
                    if (_rb.velocity.y != 0)
                    {
                        PlayBounce();
                    }
                    else
                        _anim.Play("Idle");
                }*/
    }

    private void PlayBounce()
    {
        if (_playerControler.IsGrounded())
            _anim.Play("Squish2");
        else
            _anim.Play("squash2");
    }

    // Calculate the Jump power 
/*    public void PlaySquishSquash(InputAction.CallbackContext context)
    {
        if (_playerControler.IsGrounded())
        {
            if (context.performed && _playerControler.PlayerSpeed == 0f)
            {
                squishAnimationIsPlaying = true;
                _anim.Play("Squish");
                SoundManager.Instance.PlaySquish();
            }
            if (context.canceled)
            {
                _anim.Play("Squash");
                SoundManager.Instance.PlaySquash();
            }
        }
    }*/

}
