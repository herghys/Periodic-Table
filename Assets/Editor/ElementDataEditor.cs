using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Element))]
public class ElementDataEditor : Editor
{
    #region Variables
    SerializedProperty elementNumProp = null;
    SerializedProperty elementNameProp = null;
    SerializedProperty elementSymbolProp = null;
    SerializedProperty elementStateProp = null;
    SerializedProperty atomicMassProp = null;
    SerializedProperty elementTypeProp = null;
    SerializedProperty electronConfigprop = null;
    SerializedProperty oxydationStateProp = null;
    SerializedProperty electronegativityProp = null;
    SerializedProperty atomicRadProp = null;
    SerializedProperty ionizationEnergyProp = null;
    SerializedProperty electronAffinityProp = null;
    SerializedProperty meltingPointProp = null;
    SerializedProperty boilingPointProp = null;
    SerializedProperty densityProp = null;
    SerializedProperty yearDiscoveredProp = null;
    #endregion

    #region Unity Defaults
    // Start is called before the first frame update
    void OnEnable()
    {
        elementNumProp          = serializedObject.FindProperty("_elementNum");
        elementNameProp         = serializedObject.FindProperty("_elementName");
        elementSymbolProp       = serializedObject.FindProperty("_elementSymbol");
        elementStateProp        = serializedObject.FindProperty("_elementState");
        elementTypeProp         = serializedObject.FindProperty("_elementType");
        atomicMassProp          = serializedObject.FindProperty("_atomicMass");
        electronConfigprop      = serializedObject.FindProperty("_electronConfig");
        oxydationStateProp      = serializedObject.FindProperty("_oxydationState");
        electronegativityProp   = serializedObject.FindProperty("_electronegativity");
        atomicRadProp           = serializedObject.FindProperty("_atomicRadius");
        ionizationEnergyProp    = serializedObject.FindProperty("_ionizationEnergy");
        electronAffinityProp    = serializedObject.FindProperty("_electronAffinity");
        meltingPointProp        = serializedObject.FindProperty("_meltingPoint");
        boilingPointProp        = serializedObject.FindProperty("_boilingPoint");
        densityProp             = serializedObject.FindProperty("_density");
        yearDiscoveredProp      = serializedObject.FindProperty("_yearDiscovered");
    }

    public override void OnInspectorGUI()
    {
        var prefabSrc = (Element) target;
        #region Style
        GUIStyle textFieldStyle = new GUIStyle(EditorStyles.textField)
        {
            fontSize = 12, fixedHeight = 20, alignment = TextAnchor.MiddleLeft
        };

        GUIStyle textAreaStyle = new GUIStyle(EditorStyles.textField)
        {
            fontSize = 12,
            fixedHeight = 60,
            stretchHeight = true,
            wordWrap= true
        };
        #endregion
        elementNumProp.intValue = EditorGUILayout.IntField("Element Number", elementNumProp.intValue, textFieldStyle); GUILayout.FlexibleSpace();
        elementNameProp.stringValue = EditorGUILayout.TextField("Element Name", elementNameProp.stringValue, textFieldStyle); GUILayout.FlexibleSpace();
        elementSymbolProp.stringValue = EditorGUILayout.TextField("Element Symbol", elementSymbolProp.stringValue, textFieldStyle); GUILayout.FlexibleSpace();
        elementStateProp.stringValue = EditorGUILayout.TextField("Element State", elementStateProp.stringValue, textFieldStyle); GUILayout.FlexibleSpace();
        EditorGUILayout.PropertyField(elementTypeProp, new GUIContent("Element Type", "Specify this element type")); GUILayout.FlexibleSpace();
        atomicMassProp.doubleValue = EditorGUILayout.DoubleField("Atomic Mass", atomicMassProp.doubleValue, textFieldStyle); GUILayout.FlexibleSpace();

        EditorGUILayout.LabelField("Electron Config");
        electronConfigprop.stringValue = EditorGUILayout.TextArea( electronConfigprop.stringValue, textAreaStyle); GUILayout.FlexibleSpace();

        oxydationStateProp.stringValue = EditorGUILayout.TextField("Oxydation State", oxydationStateProp.stringValue, textFieldStyle); GUILayout.FlexibleSpace();
        electronegativityProp.doubleValue = EditorGUILayout.DoubleField("Electronegativity", electronegativityProp.doubleValue, textFieldStyle); GUILayout.FlexibleSpace();
        atomicRadProp.doubleValue = EditorGUILayout.DoubleField("Atomic Radius", atomicRadProp.doubleValue, textFieldStyle); GUILayout.FlexibleSpace();
        ionizationEnergyProp.doubleValue = EditorGUILayout.DoubleField("Ionization Energy", ionizationEnergyProp.doubleValue, textFieldStyle); GUILayout.FlexibleSpace();
        electronAffinityProp.doubleValue = EditorGUILayout.DoubleField("Electron Affinity", electronAffinityProp.doubleValue, textFieldStyle); GUILayout.FlexibleSpace();
        meltingPointProp.doubleValue = EditorGUILayout.DoubleField("Melting Point", meltingPointProp.doubleValue, textFieldStyle); GUILayout.FlexibleSpace();
        boilingPointProp.doubleValue = EditorGUILayout.DoubleField("Boiling Point", boilingPointProp.doubleValue, textFieldStyle); GUILayout.FlexibleSpace();
        densityProp.doubleValue = EditorGUILayout.DoubleField("Density", densityProp.doubleValue, textFieldStyle); GUILayout.FlexibleSpace();
        yearDiscoveredProp.stringValue = EditorGUILayout.TextField("Year Discovery", yearDiscoveredProp.stringValue, textFieldStyle); GUILayout.FlexibleSpace();
        prefabSrc.Prefabs = (GameObject)EditorGUILayout.ObjectField("Prefab", prefabSrc.Prefabs, typeof(GameObject), false); GUILayout.FlexibleSpace();

        serializedObject.ApplyModifiedProperties();
    }
    #endregion
}
