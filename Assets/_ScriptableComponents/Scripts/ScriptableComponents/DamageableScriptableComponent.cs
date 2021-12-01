using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;


public class DamageEventData {
    public Entity Source;
    public Entity Target;
    public float Amount = 0;
}

[CreateAssetMenu(fileName = "New DamageableScriptableComponent",menuName = "ScriptableComponents/Components/Damageable")]
[Serializable]
public class DamageableScriptableComponent : ScriptableComponent {
    public StatScriptableObject DamageableStat;

    public void TakeDamage(DamageEventData inputEventData) {
        StatsAspect targetStatsAspect = inputEventData.Target.GetAspect<StatsAspect>();
        var damageableComponent = inputEventData.Target.ScriptableComponents.FirstOrDefault(component => component is DamageableScriptableComponent) as DamageableScriptableComponent;
        if (targetStatsAspect == null || damageableComponent == null) {
            if (targetStatsAspect == null) {
                Debug.LogFormat("TakeDamage() failed - StatsAspect not found!");
            }

            if (damageableComponent == null) {
                Debug.LogFormat("TakeDamage() failed - DamageableComponent not found!");
            }
        } else {
            Debug.LogFormat("Damage received!");
            Debug.LogFormat("Actually applying damage here isn't working");
            targetStatsAspect.GetStats().FirstOrDefault(stat => string.Equals(stat.Name,DamageableStat.Name)).Value -= inputEventData.Amount;
        }
    }
}