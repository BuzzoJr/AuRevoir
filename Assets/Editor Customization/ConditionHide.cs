using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ConditionalHideAttribute : PropertyAttribute
{
    public string ConditionalSourceField { get; }
    public bool HideInInspector { get; }

    public ConditionalHideAttribute(string conditionalSourceField, bool hideInInspector = true)
    {
        ConditionalSourceField = conditionalSourceField;
        HideInInspector = hideInInspector;
    }
}

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(ConditionalHideAttribute))]
public class ConditionalHidePropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        ConditionalHideAttribute condHAtt = (ConditionalHideAttribute)attribute;
        bool enabled = GetConditionalHideAttributeResult(condHAtt, property);

        bool wasEnabled = GUI.enabled;
        GUI.enabled = enabled;

        if (!condHAtt.HideInInspector || enabled)
        {
            EditorGUI.PropertyField(position, property, label, true);
        }

        GUI.enabled = wasEnabled;
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        ConditionalHideAttribute condHAtt = (ConditionalHideAttribute)attribute;
        bool enabled = GetConditionalHideAttributeResult(condHAtt, property);

        if (!condHAtt.HideInInspector || enabled)
        {
            return EditorGUI.GetPropertyHeight(property, label);
        }

        return -EditorGUIUtility.standardVerticalSpacing; // Hides the property
    }

    private bool GetConditionalHideAttributeResult(ConditionalHideAttribute condHAtt, SerializedProperty property)
    {
        bool enabled = true;
        string propertyPath = property.propertyPath; // e.g. PlayerSettings.Health
        string conditionPath = propertyPath.Replace(property.name, condHAtt.ConditionalSourceField); // e.g. PlayerSettings.HideHealth
        SerializedProperty sourcePropertyValue = property.serializedObject.FindProperty(conditionPath);

        if (sourcePropertyValue != null)
        {
            enabled = sourcePropertyValue.boolValue;
        }
        else
        {
            Debug.LogWarning($"ConditionalHideAttribute: Could not find a property with the name '{condHAtt.ConditionalSourceField}' in object '{property.serializedObject.targetObject}'.");
        }

        return enabled;
    }
}
#endif