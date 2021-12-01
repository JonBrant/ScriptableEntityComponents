using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TheLiquidFire.AspectContainer;
using UnityEngine;


public class Stat {
    public string Name = "Default Stat Name";
    
    public Action<float> OnValueChanged;
    public float Value {
        get {
            return _value;
        }
        set {
            if (!_value.Equals(Value)) {
                OnValueChanged?.Invoke(Value);
            }
            _value = Value;
            
        }
    }
    private float _value = 0;

    public Stat(string inputStatName,float inputValue) {
        Name = inputStatName;
        _value = inputValue;
    }
}

public class StatsAspect : Aspect {
    List<Stat> stats = new List<Stat>();
    public void AddStat(Stat inputStat) {
        if (stats.All(stat => stat.Name != inputStat.Name)) {
            stats.Add(inputStat);
        }
    }

    public List<Stat> GetStats() {
        return stats;
    }
}