using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Element))]
public class ElementDataEditor : Editor
{
    #region Variables
    SerializedProperty elementNumProp = null;
    SerializedProperty elementNameProp = null;
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
        GUIStyle textAreaStyle = new GUIStyle(EditorStyles.textArea)
        {
            fontSize = 12, fixedHeight = 17, alignment = TextAnchor.MiddleLeft
        };
        #endregion
        GUILayout.Label("Elements", EditorStyles.miniLabel);
        elementNumProp.intValue = EditorGUILayout.IntField("Element Number", elementNumProp.intValue, textAreaStyle); GUILayout.FlexibleSpace();
        elementNameProp.stringValue = EditorGUILayout.TextField("Element Name", elementNameProp.stringValue, textAreaStyle); GUILayout.FlexibleSpace();
        EditorGUILayout.PropertyField(elementTypeProp, new GUIContent("Element Type", "Specify this element type")); GUILayout.FlexibleSpace();
        atomicMassProp.doubleValue = EditorGUILayout.DoubleField("Atomic Mass", atomicMassProp.doubleValue, textAreaStyle); GUILayout.FlexibleSpace();
        electronConfigprop.stringValue = EditorGUILayout.TextField("Electron Config", electronConfigprop.stringValue, textAreaStyle); GUILayout.FlexibleSpace();
        oxydationStateProp.stringValue = EditorGUILayout.TextField("Oxydation State", oxydationStateProp.stringValue, textAreaStyle); GUILayout.FlexibleSpace();
        electronegativityProp.doubleValue = EditorGUILayout.DoubleField("Electronegativity", electronegativityProp.doubleValue, textAreaStyle); GUILayout.FlexibleSpace();
        atomicRadProp.doubleValue = EditorGUILayout.DoubleField("Atomic Radius", atomicRadProp.doubleValue, textAreaStyle); GUILayout.FlexibleSpace();
        ionizationEnergyProp.doubleValue = EditorGUILayout.DoubleField("Ionization Energy", ionizationEnergyProp.doubleValue, textAreaStyle); GUILayout.FlexibleSpace();
        electronAffinityProp.doubleValue = EditorGUILayout.DoubleField("Electron Affinity", electronAffinityProp.doubleValue, textAreaStyle); GUILayout.FlexibleSpace();
        meltingPointProp.doubleValue = EditorGUILayout.DoubleField("Melting Point", meltingPointProp.doubleValue, textAreaStyle); GUILayout.FlexibleSpace();
        boilingPointProp.doubleValue = EditorGUILayout.DoubleField("Boiling Point", boilingPointProp.doubleValue, textAreaStyle); GUILayout.FlexibleSpace();
        densityProp.doubleValue = EditorGUILayout.DoubleField("Density", densityProp.doubleValue, textAreaStyle); GUILayout.FlexibleSpace();
        yearDiscoveredProp.stringValue = EditorGUILayout.TextField("Year Discovery", yearDiscoveredProp.stringValue, textAreaStyle); GUILayout.FlexibleSpace();
        prefabSrc.Prefabs = (GameObject)EditorGUILayout.ObjectField("Prefab", prefabSrc.Prefabs, typeof(GameObject), false); GUILayout.FlexibleSpace();

        serializedObject.ApplyModifiedProperties();
    }
    #endregion
}
