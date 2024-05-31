using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private LayerMask _groundLayer;
    [SerializeField]
    private Transform _groundChecker;
    [SerializeField]
    private float _jumpPower;
    [SerializeField]
    private float _maxHoldTime = 2f, _minHoldTime = 1f;

    private Rigidbody2D _rb;
    private float _xValue;
    private float _jumpBtnPressDuration;
    private bool startCount;
    private float timecounter;
    private float originalSpeed;
    private BallBounce _ballbounce;
    private Animator _anim;

    public float PlayerSpeed;

    internal bool playSquish = false, playSquash = false;


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _ballbounce = GetComponent<BallBounce>();
        _anim = GetComponent<Animator>();
        originalSpeed = PlayerSpeed;
        ToggleBouncing(true);
    }
    private void Update()
    {
        if (_rb.velocity.y != 0)
            PlayerSpeed = originalSpeed;
        FlipPlayer();
        CalculateJumpHight();
        if (_anim.GetCurrentAnimatorStateInfo(0).IsTag("Squash"))
        {
            playSquash = false;
        }

        if(_rb.velocity.x != 0)
        {
            playSquish = false;

        }
        
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void MovePlayer()
    {
        _rb.velocity = new Vector2(_xValue * PlayerSpeed, _rb.velocity.y);
    }
    
    // Read player x value
    public void GetHorizontalInput(InputAction.CallbackContext context)
    {
        _xValue = context.ReadValue<Vector2>().x;
    }

    // Calculate the Jump power 
    public void GetJumpDuration(InputAction.CallbackContext context)
    {
        if (_rb.velocity.y == 0f)
        {
            if (context.performed)
            {
                playSquish = true;
                PlayerSpeed = 0;
                startCount = true;
                Debug.Log("performed");
                StartCoroutine(StopBouncing());

            }
            if (context.canceled && PlayerSpeed == 0f)
            {
                playSquish = false;
                playSquash = true;
                Debug.Log("Canceled");
                PlayerSpeed = originalSpeed;
                startCount = false;
                _jumpBtnPressDuration = Mathf.Clamp(timecounter, _minHoldTime, _maxHoldTime);
                PlayerJump();
                _jumpBtnPressDuration = timecounter = 0;
            }
        }

    }

    // Stop Bouncing when you click on a button
    public void StopBounceAction(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            Debug.Log("I Was Clicked");
            StartCoroutine(StopBouncing());
        }
    }

    private void CalculateJumpHight()
    {
        if (startCount)
        {
            timecounter += Time.deltaTime;       
        }
    }

    private void PlayerJump()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, _jumpPower * _jumpBtnPressDuration);
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundChecker.position, .2f, _groundLayer);
    }

    private void ToggleBouncing(bool val)
    {
        _ballbounce.canBounce = val;
    }
    private IEnumerator StopBouncing()
    {
        ToggleBouncing(false);
        yield return new WaitForSeconds(.4f);
        ToggleBouncing(true);

    }

    // flip the player based on the direction he want to move in
    private void FlipPlayer()
    {
        Vector2 localScale = transform.localScale;

        if (_xValue > 0)
        {
            localScale = new Vector2(Mathf.Abs(localScale.x), localScale.y);
        }
        else if (_xValue < 0)
        {
            localScale = new Vector2(-Mathf.Abs(localScale.x), localScale.y);
        }

        transform.localScale = localScale;
    }
}
