using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private float _jumpforce;
    private Vector3 _force;
    private bool canJunp;

    private void Start()
    {
        _force.y = _jumpforce;
        canJunp = true;
    }

    private void Update()
    {
        if (InputManager.Instance.GetAxis("Vertical") > 0.1)
        {
            if (canJunp)
            {
                _rigidbody.AddForce(_force,ForceMode.Impulse);
                canJunp = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(_force,ForceMode.Impulse);
            transform.position = transform.position += _force;
            Debug.Log("Presed Space");
        }

        if (transform.position.y <= 0.7)
            canJunp = true;
    }
}
