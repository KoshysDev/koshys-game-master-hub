using System.IO;
using UnityEngine;

public static class ExplorerUtils
{
    public static void CheckFolderExist(string path)
    {
        if (!Directory.Exists(path))
        {
            Debug.Log("No folder found in path: " + path + ". It will be created.");

            Directory.CreateDirectory(path);
        }
    }

    public static void CheckFileExist(string path)
    {
        if (File.Exists(path))
        {
            Debug.Log("Found data for category: " + path);
        }
        else
        {
            Debug.LogWarning("Category not found: " + path + " in: " + path);
            File.Create(path).Close();
            Debug.Log("File " + path + ". Created!");
        }
    }
}
