using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour, IService
{
    [SerializeField] private Transform container;
    [SerializeField] private GameObject[] popups; 

    private Dictionary<Type, GameObject> popupDict = new Dictionary<Type, GameObject>();

    private GameObject lastPopup;
    private void Start()
    {
        ServiceLocator.Instance.Register(this);
    }
    public IEnumerator Init()
    {
        BuildDictionary();
        yield return new WaitForEndOfFrame();
    }
    private void BuildDictionary()
    {
        popupDict.Clear();
        foreach (var prefab in popups)
        {
            if (prefab == null) continue;

            Type type = prefab.GetComponent<BasePopup<object>>()?.GetType();
            if (type != null && !popupDict.ContainsKey(type))
            {
                popupDict.Add(type, prefab);
            }
        }
    }

    public TPopup Create<TPopup>() where TPopup : BasePopup<object>
    {
        if (!popupDict.TryGetValue(typeof(TPopup), out var prefab))
            return null;

        GameObject obj = Instantiate(prefab, container);
        TPopup popup = obj.GetComponent<TPopup>();
        if (popup == null)
        {
            Destroy(obj);
            return null;
        }

        if(lastPopup != null)
            Destroy(lastPopup);

        lastPopup = obj;
        return popup;
    }
}