using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New MouseDownScriptableComponent", menuName = "ScriptableComponents/Components/MouseDown")]
[Serializable]
public class MouseDownScriptableComponent : ScriptableComponent,IAwake, IDestroy {
    public ScriptableAction MouseDownAction;

    private void OnMouseDownEventHandler(Entity inputEntity) {
        //Debug.LogFormat("OnMouseDown({0})", inputEntity.gameObject.name);
        if (MouseDownAction != null) {
            MouseDownAction?.Execute(inputEntity);
        }
    }

    public void SCAwake(Entity inputEntity) { inputEntity.OnMouseDownEvent += OnMouseDownEventHandler; }

    public void SCDestroy(Entity inputEntity) { inputEntity.OnMouseDownEvent -= OnMouseDownEventHandler; }
}