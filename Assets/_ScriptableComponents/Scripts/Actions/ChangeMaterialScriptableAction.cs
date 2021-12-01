using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New ChangeMaterial Action",menuName = "ScriptableComponents/Actions/ChangeMaterial")]
public class ChangeMaterialScriptableAction : ScriptableAction {
    public Material Material;

    public override void Execute(Entity inputEntity) {
        //Debug.LogFormat("RaiseEventScriptableAction.Execute(This: {0}, Target: {1})",this.name,inputEntity.gameObject.name);
        if (Material != null && inputEntity.TryGetComponent(out Renderer entityRenderer)) {
            entityRenderer.material = Material;
        } else {
            Debug.LogFormat("{0} failed to find renderer on {1}",this.name,inputEntity.gameObject.name);
        }
    }
}