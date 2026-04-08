using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : IService
{
    private static readonly string saveKey = "peaky_group_save";
    private Data data;

    public IEnumerator Init()
    {
        Load();
        yield return new WaitForEndOfFrame();
    }
    public void Save()
    {
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(saveKey, json);
        PlayerPrefs.Save();
    }
    private void Load()
    {
        if (PlayerPrefs.HasKey(saveKey))
        {
            string json = PlayerPrefs.GetString(saveKey);
            data = JsonUtility.FromJson<Data>(json);
        }
        else
        {
            data = new Data();
        }
    }

    public CellEntry GetCellEntryById(string id)
    {
        for (int i = 0; i < data.cells.Count; i++)
            if (data.cells[i].id == id)
                return data.cells[i];

        var entry = new CellEntry(id);
        data.cells.Add(entry);
        return entry;
    }

    [Serializable]
    public class Data
    {
        public List<CellEntry> cells = new List<CellEntry>();
    }
}

[Serializable]
public class CellEntry
{
    public string id;
    public bool isOccupied;
    public string buildingId;
    public CellEntry(string id)
    {
        this.id = id;
        isOccupied = false;
        buildingId = null;
    }
}