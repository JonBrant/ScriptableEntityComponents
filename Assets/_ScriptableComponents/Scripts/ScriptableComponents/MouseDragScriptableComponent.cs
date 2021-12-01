using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New MouseDragScriptableComponent",menuName = "ScriptableComponents/Components/MouseDrag")]
[Serializable]
public class MouseDragScriptableComponent : ScriptableComponent, IAwake, IDestroy {
    public ScriptableAction MouseDragAction;

    private void OnMouseDragEventHandler(Entity inputEntity) {
        Debug.LogFormat("OnMouseDrag({0})", inputEntity.gameObject.name);
        if (MouseDragAction != null) {
            MouseDragAction?.Execute(inputEntity);
        }
    }

    public void SCAwake(Entity inputEntity) { inputEntity.OnMouseDragEvent += OnMouseDragEventHandler;}

    public void SCDestroy(Entity inputEntity) { inputEntity.OnMouseDragEvent -= OnMouseDragEventHandler; }
}