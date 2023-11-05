using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatterBehaviour : MonoBehaviour
{
    [SerializeField] private bool _isCorrutineRuning;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _moveTime;
    [SerializeField] private Vector3 _force;
    private void FixedUpdate()
    {
        if (!_isCorrutineRuning)
        {
            StopCoroutine(MoveWatter());
            StartCoroutine(MoveWatter());
        }
    }
    
    private IEnumerator MoveWatter()
    {
        _isCorrutineRuning = true;
        yield return new WaitForSeconds(_moveTime);
        _rigidbody.AddForce(_force,ForceMode.Force);
        yield return null;
        _isCorrutineRuning = false;
        yield return null;
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.collider.tag == "Bridge")
            BridgeFactory.Instance?.DestroyProduct(other.collider?.GetComponentInParent<BridgeController>());
        if (other.collider.tag == "Spawn")
            Destroy(other.collider.gameObject);
    }
}
