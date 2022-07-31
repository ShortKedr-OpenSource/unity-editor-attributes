using UnityEngine;

namespace CustomEditorAttributes.Examples {
    public class InspectorAttributesExample : MonoBehaviour {

        [Header("ReadOnly:")]
        [SerializeField] [ReadOnly] private float floatValue;

        
        [Header("Relabel:")] 
        
        [Relabel("MyCustomLabel")]
        [SerializeField] private int intValue;

        
        [Header("Conditional:")] 
        [SerializeField] private bool haveMana = true;
        
        [Conditional(nameof(haveMana), true)]
        [SerializeField]  private float manaPool = 200;
    }
}