using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[CreateAssetMenu(fileName = "GameUtility", menuName = "Game Utility")]
public class GameUtility : ScriptableObject
{
    public delegate void ElementDescriptionCallback(Element element, Color color, string elementType);
    public ElementDescriptionCallback UpdateElement = null;

    public delegate void UpdateContextUICallback(bool state);
    public UpdateContextUICallback UpdateContextUI;

    private Dictionary<string, Element> elementData  = new Dictionary<string, Element>();
    public Dictionary<string, Element> ElementData
    {
        get { return elementData; }
        set { elementData = value; }
    }
}