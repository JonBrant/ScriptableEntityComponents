using System;
using System.Collections;
using System.Collections.Generic;
using TheLiquidFire.AspectContainer;
using UnityEngine;
using UnityEngine.UI;




[CreateAssetMenu(fileName = "New StatsScriptableComponent",menuName = "ScriptableComponents/Components/StatComponent")]
[Serializable]
public class StatsScriptableComponent : ScriptableComponent,IAwake {
    public List<StatScriptableObject> DefaultStats = new List<StatScriptableObject>();

    public void SCAwake(Entity inputEntity) {
        StatsAspect StatsAspect = inputEntity.AddAspect<StatsAspect>();
        foreach (StatScriptableObject stat in DefaultStats) {
            Stat statToAdd = stat.GetStat();
            StatsAspect.AddStat(statToAdd);
        }
    }
}