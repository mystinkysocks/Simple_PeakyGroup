using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour, IService
{
    [SerializeField] private Transform container;
    [SerializeField] private BasePopup[] prefabs;

    private Dictionary<Type, BasePopup> dict = new Dictionary<Type, BasePopup>();
    private BasePopup lastPopup;

    private void Start()
    {
        ServiceLocator.Instance.Register(this);
    }

    public IEnumerator Init()
    {
        BuildDictionary();
        yield return null;
    }

    private void BuildDictionary()
    {
        dict.Clear();
        foreach (var popup in prefabs)
        {
            if (popup == null) continue;

            Type type = popup.GetType();
            if (!dict.ContainsKey(type))
            {
                dict.Add(type, popup);
            }
        }
    }

    public TPopup Create<TPopup>() where TPopup : BasePopup
    {
        if (!dict.TryGetValue(typeof(TPopup), out var prefab))
            return null;

        BasePopup obj = Instantiate(prefab, container);
        TPopup popup = obj as TPopup;
        if (popup == null)
        {
            Destroy(obj.gameObject);
            return null;
        }

        if (lastPopup != null)
            Destroy(lastPopup.gameObject);

        lastPopup = popup;
        return popup;
    }
}