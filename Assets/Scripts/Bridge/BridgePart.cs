using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgePart : MonoBehaviour
{
    private bool isColliding;

    public bool IsColliding
    {
        get { return isColliding; }
        private set { isColliding = value; }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Im here");
        if (other.gameObject.tag == "Bridge")
            isColliding = true;
    }
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Im here");
        if (other.collider.gameObject.tag == "Bridge")
            isColliding = true;
    }
}