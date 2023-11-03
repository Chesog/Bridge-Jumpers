using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeManager : MonoBehaviour
{
    [SerializeField] private float _spawnTime;
    [SerializeField] private BridgeController _currentBridge;
    [SerializeField] private bool isCorrutineRuning;

    private void OnEnable()
    {
        isCorrutineRuning = false;
    }

    private void Update()
    {
        if (!isCorrutineRuning)
        {
            StopCoroutine(SpawnBridge());
            StartCoroutine(SpawnBridge());
        }

    }

    private IEnumerator SpawnBridge()
    {
        isCorrutineRuning = true;
         yield return new WaitForSeconds(_spawnTime);
         Vector3 spawnPos = _currentBridge.transform.position;
         spawnPos.y += 3.65f;
         _currentBridge = (BridgeController)BridgeFactory.Instance.GetProduct(spawnPos);
         yield return null;
         isCorrutineRuning = false;
         yield return null;
    }
}
