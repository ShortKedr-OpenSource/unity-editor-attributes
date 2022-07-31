using UnityEngine;

namespace CustomEditorAttributes {
    /// <summary>
    /// Show inspector property only if target property equals to show value
    /// </summary>
    public class ConditionalAttribute : PropertyAttribute {
        public readonly string PropertyName;
        public readonly object ShowValue;

        public ConditionalAttribute(string propertyName, object showValue) {
            this.PropertyName = propertyName;
            this.ShowValue = showValue;
        }
    }
}