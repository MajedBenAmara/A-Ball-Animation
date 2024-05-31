using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _lastVelocity;
    private Animator _anim;
    internal bool canBounce;
    internal bool isBouncing;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        _lastVelocity = _rb.velocity;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (canBounce)
        {
            var speed = _lastVelocity.magnitude;
            var direction = Vector2.Reflect(_lastVelocity.normalized, collision.contacts[0].normal);
            isBouncing = true;
            _rb.velocity = direction * Mathf.Max(speed, 2f);
            SoundManager.Instance.PlayBounce();
        }
        else
            isBouncing = false;


    }
}
