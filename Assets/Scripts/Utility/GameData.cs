using System.Collections.Generic;

public static class GameData
{
    //Scene To Load
    static string _scene;
    public static string SceneToLoad
    {
        get { return _scene; }
        set { _scene = value; }
    }

    //Update Element
    public delegate void ElementDescriptionCallback(Element element, UnityEngine.Color color, string elementType);
    public static ElementDescriptionCallback UpdateElement = null;

    //Update Selected/Unselected
    public delegate void ElementCardTypeCallback();
    public static ElementCardTypeCallback UpdateUnselectedType;

    //Update Context UI State
    public delegate void UpdateContextUICallback(bool state);
    public static UpdateContextUICallback UpdateContextUI;
    public static UpdateContextUICallback UpdateSideMenuUI;

    //Selected Element
    private static Dictionary<ElementType, bool> selectedElement = new Dictionary<ElementType, bool>();
    public static Dictionary<ElementType, bool> IsSelectedElement
    {
        get { return selectedElement; }
        set { selectedElement = value; }
    }

    //Element List
    private static Dictionary<string, Element> elementData = new Dictionary<string, Element>();
    public static Dictionary<string, Element> ElementData
    {
        get { return elementData; }
        set { elementData = value; }
    }
}
