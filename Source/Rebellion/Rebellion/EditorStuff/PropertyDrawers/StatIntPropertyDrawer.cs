using System;

using UnityEngine;
using UnityEditor;

using Rebellion.Data.Stats;

namespace Rebellion.EditorStuff
{
    [CustomPropertyDrawer(typeof(StatInt), true)]
    public class StatIntPropertyDrawer : PropertyDrawer
    {
        private const float kStatFieldWidth = 64f;
        private const float kStatFieldBuffer = 8f;
        private const float kPropertyIndent = 12f;
        private static GUIStyle sValueLabelStyle = null;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (sValueLabelStyle == null)
            {
                sValueLabelStyle = new GUIStyle(GUI.skin.label);
                sValueLabelStyle.alignment = TextAnchor.MiddleCenter;
            }

            EditorGUI.BeginProperty(position, label, property);

            GUI.Box(position, GUIContent.none, GUI.skin.textArea);

            Rect labelPos = new Rect(position);
            labelPos.height = EditorGUIUtility.singleLineHeight;
            labelPos.x += kPropertyIndent;
            labelPos.y += EditorGUIUtility.singleLineHeight;     
       
            labelPos = EditorGUI.PrefixLabel(labelPos, GUIUtility.GetControlID(FocusType.Passive), label, EditorStyles.boldLabel);

            Rect statPos = new Rect(labelPos.x, position.y + 6f, kStatFieldWidth, EditorGUIUtility.singleLineHeight);

            DrawProperty(statPos, "Value", property);

            statPos.x += kStatFieldWidth + kStatFieldBuffer;

            DrawProperty(statPos, "MinValue", property);

            statPos.x += kStatFieldWidth + kStatFieldBuffer;

            DrawProperty(statPos, "MaxValue", property);

            EditorGUI.EndProperty();
        }

        public void DrawProperty(Rect position, string propertyRelativeName, SerializedProperty property)
        {
            EditorGUI.LabelField(position, propertyRelativeName, sValueLabelStyle);

            position.y += EditorGUIUtility.singleLineHeight + 4f;

            EditorGUI.PropertyField(position, property.FindPropertyRelative(propertyRelativeName), GUIContent.none);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight * 3f;
        }
    }
}
