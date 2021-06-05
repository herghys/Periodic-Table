using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[Serializable()]
public struct DescriptionHeaderUIEleements
{
    [SerializeField] TextMeshProUGUI textAtomNum;
    public TextMeshProUGUI AtomNum { get { return textAtomNum; }}

    [SerializeField] TextMeshProUGUI textAtomSymbol;
    public TextMeshProUGUI AtomSymbol { get { return textAtomSymbol; } }

    [SerializeField] TextMeshProUGUI textAtomName;
    public TextMeshProUGUI AtomName { get { return textAtomName; } }

    [SerializeField] TextMeshProUGUI textAtomMass;
    public TextMeshProUGUI AtomMass { get { return textAtomMass; } }

    [SerializeField] Image headerImage;
    public Image HeaderImage { get { return headerImage; } }
}
[Serializable()]
public struct DescriptionUIElements
{

    [SerializeField] TextMeshProUGUI textAtomName;
    public TextMeshProUGUI AtomName { get { return textAtomName; } }

    [SerializeField] TextMeshProUGUI textSymbol;
    public TextMeshProUGUI AtomSymbol { get { return textSymbol; } }

    [SerializeField] TextMeshProUGUI textAtomNum;
    public TextMeshProUGUI AtomNum { get { return textAtomNum; } }

    [SerializeField] TextMeshProUGUI textAtomState;
    public TextMeshProUGUI AtomState { get { return textAtomState; } }

    [SerializeField] TextMeshProUGUI textChemBlock;
    public TextMeshProUGUI ChemBlock { get { return textChemBlock; } }

    [SerializeField] TextMeshProUGUI textAtomMass;
    public TextMeshProUGUI AtomMass { get { return textAtomMass; } }

    [SerializeField] TextMeshProUGUI textElectronConfig;
    public TextMeshProUGUI ElectronConfig { get { return textElectronConfig; } }

    [SerializeField] TextMeshProUGUI textOxidationStates;
    public TextMeshProUGUI OxidationStates { get { return textOxidationStates; } }

    [SerializeField] TextMeshProUGUI textElectronegativity;
    public TextMeshProUGUI Electronegativity { get { return textElectronegativity; } }

    [SerializeField] TextMeshProUGUI textAtomRadius;
    public TextMeshProUGUI AtomRadius { get { return textAtomRadius; } }

    [SerializeField] TextMeshProUGUI textIonEnergy;
    public TextMeshProUGUI IonEnergy { get { return textIonEnergy; } }

    [SerializeField] TextMeshProUGUI textElectronAffinity;
    public TextMeshProUGUI ElectronAffinity { get { return textElectronAffinity; } }

    [SerializeField] TextMeshProUGUI textMeltingPoint;
    public TextMeshProUGUI MeltingPoint { get { return textMeltingPoint; } }

    [SerializeField] TextMeshProUGUI textBoilingPoint;
    public TextMeshProUGUI BoilingPoint { get { return textBoilingPoint; } }

    [SerializeField] TextMeshProUGUI textDensity;
    public TextMeshProUGUI Density { get { return textDensity; } }

    [SerializeField] TextMeshProUGUI textYear;
    public TextMeshProUGUI Year { get { return textYear; } }
}

public class PeriodicUIManager : MonoBehaviour
{
    #region Variables
    [Header("References")]
    [SerializeField] GameUtility events;
    [SerializeField] CanvasGroup group, cardGroup, sideMenu;

    [Header("Description Card References")]
    [SerializeField] DescriptionHeaderUIEleements header;
    [SerializeField] DescriptionUIElements description;

    #endregion

    #region Unity Defaults
    private void OnEnable()
    {
        events.UpdateElement += UpdateElement;
        events.UpdateContextUI += UpdateDescUI;
        events.UpdateSideMenuUI += UpdateSideMenu;
    }

    private void OnDisable()
    {
        events.UpdateElement -= UpdateElement;
        events.UpdateContextUI -= UpdateDescUI;
        events.UpdateSideMenuUI -= UpdateSideMenu;
    }
    #endregion

    #region Event Subs and Callbacks
    private void UpdateElement(Element element, Color color, string elementType)
    {
        //Desc Header
        header.AtomMass.text = element.AtomicMass;
        header.AtomName.text = element.ElementName;
        header.AtomNum.text = element.ElementNum;
        header.AtomSymbol.text = element.ElementSymbol;
        header.HeaderImage.color = color;

        //Desc Main
        if (!string.IsNullOrEmpty(element.ElementOtherName))
            description.AtomName.text = string.Format("{0} / {1}", element.ElementName, element.ElementOtherName);
        else
            description.AtomName.text = element.ElementName;

        description.AtomSymbol.text = element.ElementSymbol;
        description.AtomNum.text = element.ElementNum;
        description.AtomState.text = element.ElementState;
        description.ChemBlock.text = elementType;
        description.AtomMass.text = element.AtomicMass.ToString() + " u";
        description.ElectronConfig.text = element.ElectronConfig;
        description.OxidationStates.text = element.OxydationState;
        description.Electronegativity.text = element.Electronegativiy;
        description.AtomRadius.text = element.AtomicRadius + " pm";
        description.IonEnergy.text = element.IonizationEnergy + " eV";
        description.ElectronAffinity.text = element.ElectronAffinity + " eV";
        description.MeltingPoint.text = element.MeltingPoint + " K";
        description.BoilingPoint.text = element.MeltingPoint + " K";
        description.Density.text = element.Density + " g/cm<sup>3</sup>";
        description.Year.text = element.YearDiscovered;
    }
    private void UpdateDescUI(bool state)
    {
        if (state) UpdateDescUI(1, state);
        else UpdateDescUI(0, state);
    }

    private void UpdateSideMenu(bool state)
    {
        if (state) 
        { 
            sideMenu.alpha = 1;
            sideMenu.blocksRaycasts = true;
            sideMenu.interactable = true; 
        }
        else 
        { 
            sideMenu.alpha = 0; 
            sideMenu.blocksRaycasts = false;
            sideMenu.interactable = false; 
        }
    }
    #endregion

    #region Methods
    private void UpdateDescUI(int i, bool state)
    {
        group.alpha = i;
        group.interactable = state;

        cardGroup.alpha = i;
        cardGroup.interactable = state;
        cardGroup.blocksRaycasts = state;
    }
    #endregion
}