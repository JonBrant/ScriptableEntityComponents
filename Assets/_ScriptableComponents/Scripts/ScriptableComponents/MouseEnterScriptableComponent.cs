using System;
using UnityEngine;
using UnityEngine.Serialization;


[CreateAssetMenu(fileName = "New MouseEnterScriptableComponent",menuName = "ScriptableComponents/Components/MouseOver")]
[Serializable]
public class MouseEnterScriptableComponent : ScriptableComponent,IAwake, IDestroy {
    public ScriptableAction MouseEnterAction;

    private void OnMouseEnterEventHandler(Entity inputEntity) {
        //Debug.LogFormat("OnMouseEnter({0})", inputEntity.gameObject.name);
        if (MouseEnterAction != null) {
            MouseEnterAction?.Execute(inputEntity);
        }
    }

    public void SCAwake(Entity inputEntity) { inputEntity.OnMouseEnterEvent += OnMouseEnterEventHandler; }

    public void SCDestroy(Entity inputEntity) { inputEntity.OnMouseEnterEvent -= OnMouseEnterEventHandler; }
}