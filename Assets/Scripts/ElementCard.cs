using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent (typeof(Button))]
public class ElementCard : MonoBehaviour
{
    [SerializeField] private string atomName;
    private string fallbackAtomName = "Hydrogen";
    [SerializeField] private TextMeshProUGUI textAtomNum;
    [SerializeField] private TextMeshProUGUI textAtomSymbol;
    [SerializeField] private TextMeshProUGUI textAtomName;
    [SerializeField] private TextMeshProUGUI textAtomMass;

    [SerializeField] GameUtility gameUtility;

    private void Awake()
    {
        if (string.IsNullOrEmpty(atomName)) atomName = fallbackAtomName;
    }

    void Start()
    {
        if (gameUtility.ElementData.ContainsKey(atomName)) SetUI(gameUtility.ElementData[atomName]);
        else SetUI(gameUtility.ElementData[fallbackAtomName]);
        Debug.Log(gameUtility.ElementData["Hydrogen"].AtomicMass);
    }

    private void SetUI(Element element)
    {
        textAtomNum.text = element.ElementNum.ToString();
        textAtomSymbol.text = element.ElementSymbol;
        textAtomName.text = element.name;
        textAtomMass.text = element.AtomicMass.ToString();
    }
}
