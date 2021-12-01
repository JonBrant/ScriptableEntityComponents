using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New MoveToCursor Action",menuName = "ScriptableComponents/Actions/MoveToCursor")]
public class MoveToCursorScriptableAction : ScriptableAction {
    public override void Execute(Entity inputEntity) {
        Debug.LogFormat("Moving {0} to cursor position.",inputEntity.gameObject.name);
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(inputEntity.transform.position);
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x,Input.mousePosition.y,screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
        inputEntity.transform.position = curPosition;
    }
}