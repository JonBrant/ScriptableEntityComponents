using System;
using UnityEngine;
using UnityEngine.Serialization;


[CreateAssetMenu(fileName = "New StatsScriptableObject",menuName = "ScriptableComponents/Stat")]
[Serializable]
public class StatScriptableObject : ScriptableObject {
    [FormerlySerializedAs("StatName")] public string Name = "DefaultStateName";
    public float Value = 0;

    public Stat GetStat() {
        Stat returnStat = new Stat(Name,Value);
        return returnStat;
    }
}