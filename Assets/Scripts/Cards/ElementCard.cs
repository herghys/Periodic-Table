using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

[RequireComponent (typeof(Button))]
[RequireComponent (typeof(Image))]
[RequireComponent (typeof(CanvasGroup))]
public class ElementCard : MonoBehaviour
{
    #region Variables
    [SerializeField] private string atomName;
    [SerializeField] private TextMeshProUGUI textAtomNum;
    [SerializeField] private TextMeshProUGUI textAtomSymbol;
    [SerializeField] private TextMeshProUGUI textAtomName;
    [SerializeField] private TextMeshProUGUI textAtomMass;
    [SerializeField] private CanvasGroup canvasGroup;

    [SerializeField] ElementType mType;

    [SerializeField]
    private Button mButton;
    [SerializeField]
    private Image mImage;

    private string fallbackAtomName = "Hydrogen";
    private Element element;

    [SerializeField] GameUtility gameUtility;

    string hexColor, elementType;
    Color newCol;
    #endregion

    #region Unity Defaults

    private void OnEnable()
    {
        gameUtility.UpdateUnselectedType += SelectedType;
    }

    private void OnDisable()
    {
        gameUtility.UpdateUnselectedType -= SelectedType;
    }

    private void Awake()
    {
        mButton = GetComponent<Button>();
        mImage = GetComponent<Image>();

        //if (string.IsNullOrEmpty(atomName)) atomName = fallbackAtomName;
        atomName = gameObject.name;
        if (!gameUtility.ElementData.ContainsKey(atomName))
            atomName = fallbackAtomName;

        element = gameUtility.ElementData[atomName];

        canvasGroup = GetComponent<CanvasGroup>();

    }

    void Start()
    {
        mType = element.GetElementType;

        SetUI(gameUtility.ElementData[atomName]);
        
        ChangeColor(mType);

        SetButtonEvent();
    }
    #endregion

    #region Methods
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
                hexColor = "#1565C0"; //#1565C0 - Blue 800
                elementType = "Transition Metal";
                break;
            case ElementType.Lanthanide:
                hexColor = "#455A64"; //Blue Grey 700
                elementType = "Lanthanide";
                break;
            case ElementType.Actinide:
                hexColor = "#263238"; //Blue Grey 900
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

    private void SetUI(bool state)
    {
        if (state)
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
        else
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
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

    #region Callbacks
    private void SelectedType()
    {
        SetUI(gameUtility.IsSelectedElement[mType]);
    }
    #endregion
}
