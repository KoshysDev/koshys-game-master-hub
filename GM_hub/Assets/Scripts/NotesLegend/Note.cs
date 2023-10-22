using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class World
{
    public string worldName;
    public Texture2D mapImage; // Use Texture2D for images
    public List<Pin> pins = new List<Pin>();
    public List<Note> notes = new List<Note>();
}

[System.Serializable]
public class Pin
{
    public string pinName;
    public float posX;
    public float posY;
}

[System.Serializable]
public class Note
{
    public string title;
    public string content;
}
