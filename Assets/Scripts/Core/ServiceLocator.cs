using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IService
{
    IEnumerator Init();
}

public class ServiceLocator
{
    public static ServiceLocator Instance { get; private set; }

    private readonly Dictionary<Type, IService> services = new();

    public ServiceLocator()
    {
        Instance = this;
    }

    public void Register<T>(T service) where T : IService
    {
        var type = typeof(T);

        if (!services.TryAdd(type, service))
        {
            Debug.LogError($"Service '{type.Name}' already registered");
        }
    }
    public void Unregister<T>() where T : IService
    {
        var type = typeof(T);

        if (!services.Remove(type))
        {
            Debug.LogWarning($"Service '{type.Name}' not registered");
        }
    }
    public IEnumerable<IService> GetServices()
    {
        return services.Values;
    }
    public bool TryGet<T>(out T service) where T : IService
    {
        if (services.TryGetValue(typeof(T), out var s))
        {
            service = (T)s;
            return true;
        }

        service = default;
        return false;
    }
}