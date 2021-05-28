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

    [SerializeField] private int _elementNum;
    public int ElementNum { get { return _elementNum; } }

    [SerializeField] private string _elementName;
    public string ElementName { get { return _elementName; } }

    [SerializeField] private string _elementSymbol;
    public string ElementSymbol { get { return _elementSymbol; } }

    [SerializeField] private string _elementState;
    public string ElementState { get { return _elementState; } }

    [SerializeField] ElementType _elementType = ElementType.Nonmetal;
    public ElementType GetElementType { get { return _elementType; } }

    [SerializeField] private double _atomicMass;
    public double AtomicMass { get { return _atomicMass; } }

    [SerializeField] private string _electronConfig;
    public string ElectronConfig { get { return _electronConfig; } }

    [SerializeField] private string _oxydationState;
    public string OxydationState { get { return _oxydationState; } }

    [SerializeField] private double _electronegativity;
    public double Electronegativiy { get { return _electronegativity; } }

    [SerializeField] private double _atomicRadius;
    public double AtomicRadius { get { return _atomicRadius; } }

    [SerializeField] private double _ionizationEnergy;
    public double IonizationEnergy { get { return _ionizationEnergy; } }

    [SerializeField] private double _electronAffinity;
    public double ElectronAffinity { get { return _electronAffinity; } }

    [SerializeField] private double _meltingPoint;
    public double MeltingPoint { get { return _meltingPoint; } }

    [SerializeField] private double _boilingPoint;
    public double BoilingPoint { get { return _boilingPoint; } }

    [SerializeField] private double _density;
    public double Density { get { return _density; } }

    [SerializeField] private string _yearDiscovered;
    public string YearDiscovered { get { return _yearDiscovered; } }

    [SerializeField] private GameObject _prefabs;
    public GameObject Prefabs {
        set { _prefabs = value; }
        get { return _prefabs; } 
    }
}