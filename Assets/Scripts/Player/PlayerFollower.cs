using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    [SerializeField]
    private Transform _playerTransform;

    public float YLags = 0f;

    private void Update()
    {
        transform.position = new Vector3(_playerTransform.position.x,
            _playerTransform.position.y - YLags, _playerTransform.position.z);
    }
}
