using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController : MonoBehaviour
{
    [SerializeField] private BridgePart bridgeHalfL;
    [SerializeField] private BridgePart bridgeHalfR;
    [SerializeField] private float Speed;

    private void Update()
    {
        if (bridgeHalfL.IsColliding)
        {
            bridgeHalfL.transform.position = bridgeHalfL.transform.position;
            //bridgeHalfL.GetComponent<BridgePart>()._rigidbody.AddForce(new Vector3(0.0f,-Speed),ForceMode.Force);
        }
        else
        {
            bridgeHalfL._rigidbody.AddForce(new Vector3(Speed,0.0f),ForceMode.Force);
        }

        if (bridgeHalfR.IsColliding)
        {
            bridgeHalfR.transform.position = bridgeHalfR.transform.position;
            //bridgeHalfR.GetComponent<BridgePart>()._rigidbody.AddForce(new Vector3(0.0f,-Speed),ForceMode.Force);
        }
        else
        {
            bridgeHalfR._rigidbody.AddForce(new Vector3(-Speed,0.0f),ForceMode.Force);
        }
    }
}