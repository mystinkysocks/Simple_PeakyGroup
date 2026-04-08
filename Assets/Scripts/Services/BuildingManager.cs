using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour, IService
{
    [SerializeField] private BaseBuilding[] prefabs;

    private Dictionary<string, BaseBuilding> dict = new();
    private List<BaseBuilding> buildings = new();

    private void Start()
    {
        ServiceLocator.Instance.Register(this);
    }
    public IEnumerator Init()
    {
        for (int i = 0; i < prefabs.Length; i++)
        {
            if (!dict.TryAdd(prefabs[i].ID, prefabs[i]))
            {
                Debug.LogError($"Copy of: {prefabs[i].ID}");
            }
        }
        yield return new WaitForEndOfFrame();
    }
    public bool TryBuild(string id, Vector3 position, out BaseBuilding building)
    {
        if(dict.TryGetValue(id, out BaseBuilding prefab))
        {
            building = Instantiate(prefab, position, Quaternion.identity, transform);
            building.Init();
            buildings.Add(building);
            return true;
        }
        building = null;
        return false;
    }
    public void DestroyAll()
    {
        for(int i = 0; i < buildings.Count; i++)
        {
            Destroy(buildings[i].gameObject);
        }

        buildings.Clear();
    }
    public BaseBuilding[] GetBuildingsPrefab()
    {
        return prefabs;
    }
}