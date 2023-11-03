using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private PlayerController _player;
    
    private void FixedUpdate()
    {
        if (_player.isGrounded())
        {
            Vector3 originalPos = transform.position;
            Vector3 newPos = _player._visuals.transform.position;
            newPos.y += 3.78f;
            newPos.z -= 10.0f;
            transform.position = Vector3.Lerp(originalPos, newPos, Time.deltaTime);
            //transform.position = newPos;
        }
    }
}
