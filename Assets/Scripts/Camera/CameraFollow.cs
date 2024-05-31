using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private float _posX, _negX, _posY, _negY;

    [SerializeField]
    private Transform _playerTransform;

    [SerializeField]
    private float _transitionSpeed = .8f;
    private void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        float clampedX = Mathf.Clamp(_playerTransform.position.x, _negX, _posX);
        float clampedY = Mathf.Clamp(_playerTransform.position.y, _negY, _posY);

        transform.position = Vector3.Lerp(transform.position, 
            new Vector3(clampedX, clampedY, transform.position.z), _transitionSpeed);

    }
}
