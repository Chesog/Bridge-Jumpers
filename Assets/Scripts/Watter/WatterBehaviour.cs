using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatterBehaviour : MonoBehaviour
{
    [SerializeField] private bool _isCorrutineRuning;
    [SerializeField] private bool _canMove;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _moveTime;
    [SerializeField] private Vector3 _force;


    private void OnEnable()
    {
        _isCorrutineRuning = false;
        _canMove = true;
    }

    private void FixedUpdate()
    {
        if (!_isCorrutineRuning)
        {
            if (_canMove)
            {
                StopCoroutine(MoveWatter());
                StartCoroutine(MoveWatter());
            }
            else
            {
                StopAllCoroutines();
            }
            
        }
    }

    private IEnumerator MoveWatter()
    {
        _isCorrutineRuning = true;
        yield return new WaitForSeconds(_moveTime);
        _rigidbody.AddForce(_force, ForceMode.Force);
        yield return null;
        _isCorrutineRuning = false;
        yield return null;
    }

    private void OnCollisionEnter(Collision other)
    {
        BridgeController temp = null;
        if (other.collider.tag == "Bridge")
        {
            if (other.collider.name == "RightPart")
            {
                temp = other.collider?.GetComponentInParent<BridgeController>();
                temp.OnDestroyBridge.Invoke(temp); 
            }
        }

        if (other.collider.tag == "Spawn")
            Destroy(other.collider.gameObject);

        if (other.collider.tag == "Player")
        {
            other.collider.GetComponentInParent<PlayerController>().DestroyPlayer();
            _canMove = false;
        }
    }
}