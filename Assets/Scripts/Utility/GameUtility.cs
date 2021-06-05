using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[CreateAssetMenu(fileName = "GameUtility", menuName = "Game Utility")]
public class GameUtility : ScriptableObject
{
    //Update Card Element
    public delegate void ElementDescriptionCallback(Element element, Color color, string elementType);
    public ElementDescriptionCallback UpdateElement = null;

    //Element Card Type Selected
    public delegate void ElementCardTypeCallback();
    public ElementCardTypeCallback UpdateUnselectedType;

    //Description UI Update
    public delegate void UpdateContextUICallback(bool state);
    public UpdateContextUICallback UpdateContextUI;
    public UpdateContextUICallback UpdateSideMenuUI;

    private Dictionary<ElementType, bool> selectedElement = new Dictionary<ElementType, bool>();
    public Dictionary<ElementType, bool> IsSelectedElement
    {
        get { return selectedElement; }
        set { selectedElement = value; }
    }

    private Dictionary<string, Element> elementData  = new Dictionary<string, Element>();
    public Dictionary<string, Element> ElementData
    {
        get { return elementData; }
        set { elementData = value; }
    }
}