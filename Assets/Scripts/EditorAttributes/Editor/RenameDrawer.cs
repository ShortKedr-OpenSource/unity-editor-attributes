using UnityEditor;
using UnityEngine;

namespace CustomEditorAttributes {
    
    [CustomPropertyDrawer(typeof(RelabelAttribute))]
    public class RelabelDrawer : PropertyDrawer {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            return EditorGUI.GetPropertyHeight(property, label, true);
        }
 
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            EditorGUI.PropertyField(position, property, new GUIContent(((RelabelAttribute)attribute).NewName), true);
        }
    }
}