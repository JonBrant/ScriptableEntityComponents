using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class ScriptableAction : ScriptableObject {
    public virtual void Execute(Entity inputEntity) { }
}