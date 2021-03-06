using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ElementType
{
    Nonmetal, NobleGas, AlkaliMetal, AlkalineEarth, Metalloid,
    PostTransMetal, Halogen, TransMetal, Lanthanide, Actinide
}
[CreateAssetMenu(fileName = "ElementData", menuName = "Periodic Element")]
public class Element : ScriptableObject
{
    private string empty = "-";

    [SerializeField] private int _elementNum;
    public string ElementNum { get { return _elementNum.ToString(); } }

    [SerializeField] private string _elementName;
    public string ElementName { get { return _elementName; } }

    [SerializeField] private string _elementOtherName;
    public string ElementOtherName 
    { 
        get {  return _elementOtherName; }
        set { _elementOtherName = _elementOtherName == string.Empty ? null : value ;}
    }

    [SerializeField] private string _elementSymbol;
    public string ElementSymbol { get { return _elementSymbol; } }

    [SerializeField] private string _elementState;
    public string ElementState { get { return _elementState; } }

    [SerializeField] ElementType _elementType = ElementType.Nonmetal;
    public ElementType GetElementType { get { return _elementType; } }

    [SerializeField] private double _atomicMass;
    public string AtomicMass { get { return _atomicMass.ToString("0.####"); } }

    [SerializeField] private string _electronConfig;
    public string ElectronConfig { get { return _electronConfig; } }

    [SerializeField] private string _oxydationState;
    public string OxydationState { get { return _oxydationState; } }

    [SerializeField] private double _electronegativity;
    public string Electronegativiy { get { return _electronegativity == 0 ? empty : _electronegativity.ToString() ; } }

    [SerializeField] private double _atomicRadius;
    public string AtomicRadius { get { return _atomicRadius==0? empty: _atomicRadius.ToString() ; } }

    [SerializeField] private double _ionizationEnergy;
    public string IonizationEnergy { get { return _ionizationEnergy == 0? empty : _ionizationEnergy.ToString("0.##"); } }

    [SerializeField] private double _electronAffinity;
    public string ElectronAffinity { get { return _electronAffinity==0? empty : _electronAffinity.ToString("0.##"); } }

    [SerializeField] private double _meltingPoint;
    public string MeltingPoint { get { return _meltingPoint == 0 ? empty  : _meltingPoint.ToString("0.####") ; } }

    [SerializeField] private double _boilingPoint;
    public string BoilingPoint { get { return _boilingPoint == 0 ? empty : _boilingPoint.ToString("0.####"); } }

    [SerializeField] private double _density;
    public string Density { get { return (_density == 0) ? empty : _density.ToString("0.####"); } }


    [SerializeField] private string _yearDiscovered;
    public string YearDiscovered { get { return _yearDiscovered; } }

    /*[SerializeField] private GameObject _prefabs;
    public GameObject Prefabs {
        set { _prefabs = value; }
        get { return _prefabs; } 
    }*/
}