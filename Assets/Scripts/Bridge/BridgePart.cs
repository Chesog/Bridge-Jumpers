using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgePart : MonoBehaviour
{
    [SerializeField] private bool isColliding;
    public Rigidbody _rigidbody;


    private void Start()
    {
        if (_rigidbody == null)
            _rigidbody = GetComponent<Rigidbody>();
    }

    public bool IsColliding
    {
        get { return isColliding; }
        private set { isColliding = value; }
    }
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log($"{nameof(gameObject)} is Colliding Whit : {other.collider.gameObject.tag}");
        if (other.collider.gameObject.tag == "Bridge")
        {
            isColliding = true;
            _rigidbody.isKinematic = true;
        }

      
    }
}