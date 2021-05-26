using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameUtility", menuName = "Game Utility")]
public class GameUtility : ScriptableObject
{
    public delegate void ElementDescriptionCallback(Element element);
    public ElementDescriptionCallback UpdateWayang = null;

    public delegate void UpdateContextUICallback(bool update);
    public UpdateContextUICallback UpdateContextUI;

    private Dictionary<string, Element> elementData  = new Dictionary<string, Element>();
    public Dictionary<string, Element> ElementData
    {
        get { return elementData; }
        set { elementData = value; }
    }
}