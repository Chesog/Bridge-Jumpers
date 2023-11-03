using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController : MonoBehaviour,IProduct
{
    
    [SerializeField] private string productName = "BridgeController";
    public string ProductName { get => productName; set => productName = value ; }
    private ParticleSystem particleSystem;
    [SerializeField] private BridgePart bridgeHalfL;
    [SerializeField] private BridgePart bridgeHalfR;
    [SerializeField] private float Speed;

    private void Update()
    {
        if (bridgeHalfL.IsColliding)
        {
            bridgeHalfL.transform.position = bridgeHalfL.transform.position;
        }
        else
        {
            bridgeHalfL._rigidbody.AddForce(new Vector3(Speed,0.0f),ForceMode.Force);
        }

        if (bridgeHalfR.IsColliding)
        {
            bridgeHalfR.transform.position = bridgeHalfR.transform.position;
        }
        else
        {
            bridgeHalfR._rigidbody.AddForce(new Vector3(-Speed,0.0f),ForceMode.Force);
        }
    }
    public void Initialize()
    {
        // any unique logic to this product
        gameObject.name = productName;
        particleSystem = GetComponentInChildren<ParticleSystem>();
        particleSystem?.Stop();
        particleSystem?.Play();
    }
}