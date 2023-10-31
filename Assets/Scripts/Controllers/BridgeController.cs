using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController : MonoBehaviour
{
    [SerializeField] private GameObject bridgeHalfL;
    [SerializeField] private GameObject bridgeHalfR;
    [SerializeField] private float Speed;
    private bool canMove;

    private void Start()
    {
        canMove = false;
    }

    private void Update()
    {
        if (bridgeHalfL.GetComponent<BridgePart>().IsColliding)
            bridgeHalfL.transform.position = bridgeHalfL.transform.position;
        else
        {
            bridgeHalfL.GetComponent<Rigidbody>().AddForce(new Vector3(Speed,0.0f),ForceMode.Force);
        }

        if (bridgeHalfR.GetComponent<BridgePart>().IsColliding)
            bridgeHalfR.transform.position = bridgeHalfR.transform.position;
        else
        {
            bridgeHalfR.GetComponent<Rigidbody>().AddForce(new Vector3(-Speed,0.0f),ForceMode.Force);
        }
    }
}