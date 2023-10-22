using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class NotesManager : MonoBehaviour
{
    public List<World> worlds = new List<World>();
    private string worldsFilePath = "UserFiles/Worlds/worlds.json";

    private void Start()
    {
        LoadWorlds();
    }

    public void CreateNewWorld(World newWorld)
    {
        worlds.Add(newWorld);
        SaveWorlds();
    }

    private void SaveWorlds()
    {
        string json = JsonUtility.ToJson(new WorldWrapper { WorldList = worlds });
        File.WriteAllText(worldsFilePath, json);
    }

    private void LoadWorlds()
    {
        if (File.Exists(worldsFilePath))
        {
            string json = File.ReadAllText(worldsFilePath);
            WorldWrapper wrapper = JsonUtility.FromJson<WorldWrapper>(json);
            worlds = wrapper.WorldList.ToList();
        }
        else
        {
            worlds = new List<World>();
        }
    }
}

[System.Serializable]
public class WorldWrapper
{
    public List<World> WorldList;
}
