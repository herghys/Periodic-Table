using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameUtility", menuName = "Game Utility")]
public class GameUtility : ScriptableObject
{
    private Dictionary<string, Element> elementData  = new Dictionary<string, Element>();
    public Dictionary<string, Element> ElementData
    {
        get 
        {     
            return elementData; 
        }
        set 
        { 
            elementData = value; 
        }
    }
}