using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    public GameObject _visuals;
    public bool canJump;
    
    [SerializeField] private float _jumpforce;
    private Vector3 _force;
    private void Start()
    {
        _force.y = _jumpforce;
        if (_rigidbody == null)
            _rigidbody = GetComponentInChildren<Rigidbody>();
    }
    
    private void FixedUpdate()
    {
        if (InputManager.Instance.GetAxis("Vertical") > 0.95)
        {
            if (isGrounded())
            {
                _rigidbody.velocity = Vector3.zero;
                _rigidbody.AddForce(_force, ForceMode.Impulse);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(_force, ForceMode.Impulse);
            transform.position = transform.position += _force;
            Debug.Log("Presed Space");
        }
    }

    /// <summary>
    /// Check If The Player Is At Ground Level
    /// </summary>
    /// <returns></returns>
    public bool isGrounded()
    {
        return canJump;
    }
}