using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BridgeCollitionController : MonoBehaviour
{
    [SerializeField] private int points;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.Instance.AddScore(points);
            Destroy(this);
        }
    }
}
