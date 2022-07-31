using System;
using UnityEngine;

namespace CustomEditorAttributes {
    /// <summary>
    /// Changes default label of property in inspector
    /// </summary>
    [Serializable]
    public class RelabelAttribute : PropertyAttribute {
        [SerializeField] private string newName;
        public string NewName => newName;

        public RelabelAttribute(string newName) {
            this.newName = newName;
        }
    }
}