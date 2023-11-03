using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BridgeFactory : Factory <BridgeController>
{
    private static BridgeFactory _instance = new BridgeFactory();
    [SerializeField] private BridgeController productPrefab;
    
    private void Awake()
    {
        _instance = this;
    }

    public static BridgeFactory Instance
    {
        get
        {
            if (_instance == null)
                _instance = new BridgeFactory();

            return _instance;
        }
    }
    
    public override IProduct GetProduct(Vector3 position)
    {
        BridgeController newProduct = null;
        
        if (_factoryPool?.Count > Decimal.Zero)
        {
            newProduct = _factoryPool.First();
            newProduct.transform.position = position;
            newProduct.gameObject.SetActive(true);
            _factoryPool.Remove(_factoryPool.First());

            try
            {
                return newProduct;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        else
        {
            // create a Prefab instance and get the product component
            GameObject instance = Instantiate(productPrefab.gameObject, position, Quaternion.identity);
            newProduct = instance.GetComponent<BridgeController>();

            // each product contains its own logic
            newProduct.Initialize();

            return newProduct;
        }
    }

    private void DestroyProduct(BridgeController productPrefab)
    {
        productPrefab.gameObject.SetActive(false);
        productPrefab.gameObject.transform.position = Vector3.zero;
        _factoryPool.Add(productPrefab);
    }
}
