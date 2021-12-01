using System;
using UnityEngine;


[CreateAssetMenu(fileName = "New MouseExitScriptableComponent",menuName = "ScriptableComponents/Components/MouseExit")]
[Serializable]
public class MouseExitScriptableComponent : ScriptableComponent,IAwake,IDestroy {
    public ScriptableAction MouseExitAction;

    private void OnMouseExitEventHandler(Entity inputEntity) {
        //Debug.LogFormat("OnMouseExit({0})", inputEntity.gameObject.name);
        if (MouseExitAction != null) {
            MouseExitAction?.Execute(inputEntity);
        }
    }

    public void SCAwake(Entity inputEntity) { inputEntity.OnMouseExitEvent += OnMouseExitEventHandler; }

    public void SCDestroy(Entity inputEntity) { inputEntity.OnMouseExitEvent -= OnMouseExitEventHandler; }
}