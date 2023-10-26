using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.EventSystems;

public class MiniatureContentUI : MonoBehaviour
{
    [SerializeField] private GameObject content; // The content object where buttons will be placed
    [SerializeField] private GameObject buttonPrefab; // create button prefab

    private string miniaturesPath = Application.dataPath + "/Miniatures"; // Path to the miniatures folder

    private void Start()
    {
        //check miniatures path
        ExplorerUtils.CheckFolderExist(miniaturesPath);
    }

    public void LoadMiniatures(string category)
    {
        // Clear existing content
        ClearContent();

        // Add create content button
        AddCreateButtonForCategoty();

        // Path to category json file
        string categoryPath = miniaturesPath + "/" + category + ".json";

        //check file existence
        ExplorerUtils.CheckFileExist(categoryPath);

        //load data from file
    }

    private void AddCreateButtonForCategoty()
    {
        try
        {
            if (content == null)
            {
                throw new System.NullReferenceException("Content GameObject is not assigned. Please assign it in the Inspector.");
            }

            if (buttonPrefab == null)
            {
                throw new System.NullReferenceException("Button Prefab is not assigned. Please assign it in the Inspector.");
            }

            // Create a button
            GameObject button = Instantiate(buttonPrefab, content.transform);

            // Button customisation

            Debug.Log("Button created successfully.");
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error: " + ex.Message);
        }
    }

    private void ClearContent()
    {
        // Clear the existing content
        foreach (Transform child in content.transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void LoadMiniature(string miniatureName, string categoryPath)
    {
        // Load and display the selected miniature
        Debug.Log("Loading miniature: " + miniatureName + " from: " + categoryPath);
    }
}
