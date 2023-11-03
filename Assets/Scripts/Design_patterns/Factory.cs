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
    protected List<T> _factoryPool;
    public abstract IProduct GetProduct(Vector3 position);
    
}
