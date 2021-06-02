using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Events;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

[RequireComponent (typeof(Button))]
[RequireComponent (typeof(Image))]
public class ElementCard : MonoBehaviour
{
    #region Variables
    [SerializeField] private string atomName;
    [SerializeField] private TextMeshProUGUI textAtomNum;
    [SerializeField] private TextMeshProUGUI textAtomSymbol;
    [SerializeField] private TextMeshProUGUI textAtomName;
    [SerializeField] private TextMeshProUGUI textAtomMass;

    [SerializeField] ElementType type;

    [SerializeField]
    private Button mButton;
    [SerializeField]
    private Image mImage;

    private string fallbackAtomName = "Element 1";
    private Element element;

    [SerializeField] GameUtility gameUtility;

    string hexColor, elementType;
    Color newCol;
    #endregion

    #region Unity Defaults
    private void Awake()
    {
        mButton = GetComponent<Button>();
        mImage = GetComponent<Image>();

        //if (string.IsNullOrEmpty(atomName)) atomName = fallbackAtomName;
        atomName = gameObject.name;
        if (!gameUtility.ElementData.ContainsKey(atomName))
            atomName = fallbackAtomName;
    }

    void Start()
    {
        SetUI(gameUtility.ElementData[atomName]);
        element = gameUtility.ElementData[atomName];

        type = element.GetElementType;

        ChangeColor(element.GetElementType);
        SetButtonEvent();
    }
    #endregion

    #region UI Changer
    private void ChangeColor(ElementType type)
    {  
        switch (type)
        {
            case ElementType.Nonmetal:
                hexColor = "#FF7043"; //Deep Orange 400
                elementType = "Non Metal";
                break;
            case ElementType.NobleGas:
                hexColor = "#D84315"; //Deep orange 800
                elementType = "Noble Gas";
                break;
            case ElementType.AlkaliMetal:
                hexColor = "#EF5350";
                elementType = "Alkali Metal";
                break;
            case ElementType.AlkalineEarth:
                hexColor = "#9C27B0";
                elementType = "Alkaline Earth Metal";
                break;
            case ElementType.Metalloid:
                hexColor = "#4CAF50";
                elementType = "Metalloid";
                break;
            case ElementType.PostTransMetal:
                hexColor = "#8BC34A";
                elementType = "Post-Transition Metal";
                break;
            case ElementType.Halogen:
                hexColor = "#FF5722";
                elementType = "Halogen";
                break;
            case ElementType.TransMetal:
                hexColor = "#795548";
                elementType = "Transition Metal";
                break;
            case ElementType.Lanthanide:
                hexColor = "#B0BEC5";
                elementType = "Lanthanide";
                break;
            case ElementType.Actinide:
                hexColor = "#455A64"; //Blue Grey 800
                elementType = "Actinide";
                break;
            default:
                hexColor = "";
                break;
        }
        ColorUtility.TryParseHtmlString(hexColor, out newCol);
        mImage.color = newCol;
    }


    private void SetUI(Element element)
    {
        textAtomNum.text = element.ElementNum.ToString();
        textAtomSymbol.text = element.ElementSymbol;
        textAtomName.text = element.name;
        textAtomMass.text = element.AtomicMass.ToString();
    }
    #endregion

    #region Events
    private void SetButtonEvent()
    {
        mButton.onClick.AddListener(OnclickEvent);
    }


    private void OnclickEvent()
    {
        gameUtility.UpdateElement?.Invoke(element, newCol, elementType);
        gameUtility.UpdateContextUI?.Invoke(true);
    }
    #endregion
}
