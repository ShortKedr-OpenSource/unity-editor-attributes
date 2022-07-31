using UnityEditor;
using UnityEngine;

namespace CustomEditorAttributes {
    [CustomPropertyDrawer(typeof(ConditionalAttribute))]
    public class ConditionSerializeDrawer : PropertyDrawer {

        private ConditionalAttribute _conditionAttribute;
        private SerializedProperty _relative;
        private bool _needToDraw = false;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            
            _conditionAttribute = (ConditionalAttribute)this.attribute;
            if (_relative == null) {
                string[] pathParts = property.propertyPath.Split('.');
                string path = "";
                for (int i = 0; i < pathParts.Length - 1; i++) path += pathParts[i] + ".";
                _relative = property.serializedObject.FindProperty(path + _conditionAttribute.PropertyName);
            }

            if (_relative == null) {
                Debug.LogWarning(_conditionAttribute.PropertyName + " property not found");
                _needToDraw = false;
                return 0f;
            }
            
            object conditionValue = null;

            switch (_relative.propertyType){
                case SerializedPropertyType.Integer:
                    conditionValue = _relative.intValue;
                    break;
                case SerializedPropertyType.Boolean:
                    conditionValue = _relative.boolValue;
                    break;
                case SerializedPropertyType.Float:
                    conditionValue = _relative.floatValue;
                    break;
                case SerializedPropertyType.String:
                    conditionValue = _relative.stringValue;
                    break;
                case SerializedPropertyType.Color:
                    conditionValue = _relative.colorValue;
                    break;
                case SerializedPropertyType.ObjectReference:
                    conditionValue = _relative.objectReferenceValue;
                    break;
                case SerializedPropertyType.LayerMask:
                    Debug.LogWarning("LayerMask type not supported for " + nameof(ConditionalAttribute));
                    break;
                case SerializedPropertyType.Enum:
                    conditionValue = _relative.enumValueIndex;
                    break;
                case SerializedPropertyType.Vector2:
                    conditionValue = _relative.vector2Value;
                    break;
                case SerializedPropertyType.Vector3:
                    conditionValue = _relative.vector3Value;
                    break;
                case SerializedPropertyType.Vector4:
                    conditionValue = _relative.vector4Value;
                    break;
                case SerializedPropertyType.Rect:
                    conditionValue = _relative.rectValue;
                    break;
                case SerializedPropertyType.ArraySize:
                    Debug.LogWarning("ArraySize type not supported for " + nameof(ConditionalAttribute));
                    break;
                case SerializedPropertyType.Character:
                    Debug.LogWarning("ArraySize type not supported for " + nameof(ConditionalAttribute));
                    break;
                case SerializedPropertyType.AnimationCurve:
                    conditionValue = _relative.animationCurveValue;
                    break;
                case SerializedPropertyType.Bounds:
                    conditionValue = _relative.boundsValue;
                    break;
                case SerializedPropertyType.Gradient:
                    Debug.LogWarning("Gradient type not supported for " + nameof(ConditionalAttribute));
                    break;
                case SerializedPropertyType.Quaternion:
                    conditionValue = _relative.quaternionValue;
                    break;
                case SerializedPropertyType.ExposedReference:
                    Debug.LogWarning("ExposedReference type not supported for " + nameof(ConditionalAttribute));
                    break;
                case SerializedPropertyType.FixedBufferSize:
                    Debug.LogWarning("FixedBufferSize type not supported for " + nameof(ConditionalAttribute));
                    break;
                case SerializedPropertyType.Vector2Int:
                    conditionValue = _relative.vector2IntValue;
                    break;
                case SerializedPropertyType.Vector3Int:
                    conditionValue = _relative.vector3Value;
                    break;
                case SerializedPropertyType.RectInt:
                    conditionValue = _relative.rectIntValue;
                    break;
                case SerializedPropertyType.BoundsInt:
                    conditionValue = _relative.boundsIntValue;
                    break;
                case SerializedPropertyType.ManagedReference:
                    Debug.LogWarning("ManagedReference type not supported for " + nameof(ConditionalAttribute));
                    break;
            }
            
            if (_relative.propertyType == SerializedPropertyType.Enum) {
                if ((int) conditionValue == (int) _conditionAttribute.ShowValue) {
                    _needToDraw = true;
                    return EditorGUI.GetPropertyHeight(property, label, true);;  
                } else {
                    _needToDraw = false;
                    return -EditorGUIUtility.standardVerticalSpacing;
                }
            } else {
                if (conditionValue.Equals(_conditionAttribute.ShowValue)) {
                    _needToDraw = true;
                    return EditorGUI.GetPropertyHeight(property, label, true);
                } else {
                    _needToDraw = false;
                    return -EditorGUIUtility.standardVerticalSpacing;
                }
            }
        }
 
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            if (_needToDraw) {
                EditorGUI.PropertyField(position, property, label, true);
            }
        }
    }
}