using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New MouseUpScriptableComponent",menuName = "ScriptableComponents/Components/MouseUp")]
[Serializable]
public class MouseUpScriptableComponent : ScriptableComponent,IAwake,IDestroy {
    public ScriptableAction MouseUpAction;

    private void OnMouseUpEventHandler(Entity inputEntity) {
        //Debug.LogFormat("OnMouseUp({0})", inputEntity.gameObject.name);
        if (MouseUpAction != null) {
            MouseUpAction?.Execute(inputEntity);
        }
    }

    public void SCAwake(Entity inputEntity) { inputEntity.OnMouseUpEvent += OnMouseUpEventHandler; }

    public void SCDestroy(Entity inputEntity) { inputEntity.OnMouseUpEvent -= OnMouseUpEventHandler; }
}