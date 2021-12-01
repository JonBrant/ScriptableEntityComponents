using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[CreateAssetMenu(fileName = "New Damage Action",menuName = "ScriptableComponents/Actions/Damage")]
public class DamageEntityScriptableAction : ScriptableAction {
    public float DefaultDamage = 5;

    public override void Execute(Entity inputEntity) {
        var damageableComponent = inputEntity.ScriptableComponents.FirstOrDefault(component => component is DamageableScriptableComponent) as DamageableScriptableComponent;

        if (damageableComponent != null) {
            Debug.LogFormat("DamageAction.Execute() Entity: {0}",inputEntity.gameObject.name);
            var damageEvent = new DamageEventData();
            damageEvent.Source = null;
            damageEvent.Target = inputEntity;
            damageEvent.Amount = DefaultDamage;
            damageableComponent.TakeDamage(damageEvent);
        }
    }
}