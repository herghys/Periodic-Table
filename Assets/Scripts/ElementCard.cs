using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Events;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

[RequireComponent (typeof(Button))]
public class ElementCard : MonoBehaviour
{
    #region Variables
    [SerializeField] private string atomName;
    [SerializeField] private TextMeshProUGUI textAtomNum;
    [SerializeField] private TextMeshProUGUI textAtomSymbol;
    [SerializeField] private TextMeshProUGUI textAtomName;
    [SerializeField] private TextMeshProUGUI textAtomMass;

    [SerializeField]
    private Button mButton;

    private string fallbackAtomName = "Hydrogen";
    private Element element;

    [SerializeField] GameUtility gameUtility;
    #endregion

    #region Unity Defaults
    private void Awake()
    {
        mButton = GetComponent<Button>();

        if (string.IsNullOrEmpty(atomName)) atomName = fallbackAtomName;
        if (!gameUtility.ElementData.ContainsKey(atomName))
            atomName = fallbackAtomName;
    }

    void Start()
    {
        SetUI(gameUtility.ElementData[atomName]);
        element = gameUtility.ElementData[atomName];

        SetButtonEvent();
    }
    #endregion

    private void SetButtonEvent()
    {
        mButton.onClick.AddListener(OnclickEvent);
    }

    private void SetUI(Element element)
    {
        textAtomNum.text = element.ElementNum.ToString();
        textAtomSymbol.text = element.ElementSymbol;
        textAtomName.text = element.name;
        textAtomMass.text = element.AtomicMass.ToString();
    }

    private void OnclickEvent()
    {
        gameUtility.UpdateWayang?.Invoke(element);
    }
}
