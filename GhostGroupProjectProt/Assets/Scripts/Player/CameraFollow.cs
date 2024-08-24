using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform _player;  // Reference to the player's transform
    Vector3 _offset;    // Offset distance between the player and camera

    void Start()
    {
        // Initialize the offset if not set in the Inspector
        if (_offset == Vector3.zero)
        {
            _offset = transform.position - _player.position;
        }
    }

    void LateUpdate()
    {
        // Update the camera's position to follow the player with the offset
        transform.position = _player.position + _offset;
    }
}
