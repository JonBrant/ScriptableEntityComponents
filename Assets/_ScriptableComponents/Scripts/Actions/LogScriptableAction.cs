using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Log Action",menuName = "ScriptableComponents/Actions/Log")]
public class LogScriptableAction : ScriptableAction {
    public string Message = "Default Log message";
    public override void Execute(Entity inputEntity) { Debug.LogFormat("LogAction.Execute(This: {0}, Messages: {1})",inputEntity.gameObject.name,Message); }
}