using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] public GameObject _visuals;
    [SerializeField] private bool canJump;
    
    [SerializeField] private float _jumpforce;
    private Vector3 _force;
    [SerializeField] private float maxDistance;
    [SerializeField] private double minJumpDistance;

    private void Start()
    {
        _force.y = _jumpforce;
        if (_rigidbody == null)
            _rigidbody = GetComponentInChildren<Rigidbody>();
    }

    private void Update()
    {
        if (InputManager.Instance.GetAxis("Vertical") > 0.95)
        {
            if (isGrounded())
            {
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
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Bridge")
            canJump = true;
    }

    private void OnCollisionStay(Collision other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Bridge")
            canJump = true;
    }

    private void OnCollisionExit(Collision other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Bridge")
            canJump = false;
    }
}