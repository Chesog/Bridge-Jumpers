using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class BridgeManager : MonoBehaviour
{
    [SerializeField] private float _spawnTime;
    [SerializeField] private BridgeFactory _factory = new BridgeFactory();
    [SerializeField] private BridgeController[] productPrefab;
    [SerializeField] private BridgeController _currentBridge;
    [SerializeField] private bool isCorrutineRuning;
    [SerializeField] private bool spawnHalfBridge;
    [SerializeField] private Vector3 firstBridgeSpawn;
    private ObjectPool<BridgeController> _objectPool;

    private void OnEnable()
    {
        _objectPool = new ObjectPool<BridgeController>(() => CreatePoolObject(),
            bridge => { bridge.gameObject.SetActive(true); }, bridge => { bridge.gameObject.SetActive(false); },
            bridge => { Destroy(bridge.gameObject); }, false, 20, 50);
        isCorrutineRuning = false;
        SpawnFirstBridge();
    }

    private void Update()
    {
        if (!isCorrutineRuning)
        {
            StopCoroutine(SpawnBridge(spawnHalfBridge));
            StartCoroutine(SpawnBridge(spawnHalfBridge));
        }
    }

    private IEnumerator SpawnBridge(bool spawnHalfBridge)
    {
        BridgeController temp = null;
        isCorrutineRuning = true;
        yield return new WaitForSeconds(_spawnTime);
        _objectPool.Get(out temp);
        Vector3 spawnPos = _currentBridge.transform.position;
        spawnPos.y += 3.65f;
        if (spawnHalfBridge)
            spawnPos.x = 0.0f;

        _factory.ConfigureBridge(spawnPos, temp);
        temp.OnDestroyBridge.AddListener(OnDestroyedBridge);
        //_currentBridge = (BridgeController)BridgeFactory.Instance.GetProduct(spawnPos);
        _currentBridge = temp;
        yield return null;
        isCorrutineRuning = false;
        yield return null;
    }

    private void SpawnFirstBridge()
    {
        BridgeController temp = null;
        _objectPool.Get(out temp);
        _factory.ConfigureBridge(firstBridgeSpawn, temp);
        temp.OnDestroyBridge.AddListener(OnDestroyedBridge);
        _currentBridge = temp;
    }

    public void OnDestroyedBridge(BridgeController bridge)
    {
        bridge.OnDestroyBridge.RemoveListener(OnDestroyedBridge);
        bridge.transform.position = Vector3.zero;
        _objectPool.Release(bridge);
    }

    private BridgeController CreatePoolObject()
    {
        int bridgeToSpawn = 0;

        if (!spawnHalfBridge)
            bridgeToSpawn = 0;
        else
            bridgeToSpawn = Random.Range(1, productPrefab.Length);

        return _factory.CreatePool(Vector3.zero, productPrefab[bridgeToSpawn]);
    }
}