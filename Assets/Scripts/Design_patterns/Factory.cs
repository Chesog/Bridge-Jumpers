using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProduct
{
    public string ProductName { get; set; }

    public void Initialize();
}

public abstract class Factory <T> : MonoBehaviour
{
    protected List<T> _factoryPool = new List<T>();

    private void Start() { _factoryPool.Clear(); }

    public abstract IProduct GetProduct(Vector3 position);
}
