using System;
using System.Collections;
using System.Collections.Generic;
using TheLiquidFire.AspectContainer;
using UnityEngine;


public class Entity : MonoBehaviour,IContainer {
    #region IContainer Interface stuff
    Dictionary<string,IAspect> aspects = new Dictionary<string,IAspect>();

    public T AddAspect<T>(string key = null) where T : IAspect,new() { return AddAspect<T>(new T(),key); }

    public T AddAspect<T>(T aspect,string key = null) where T : IAspect {
        key = key ?? typeof(T).Name;
        aspects.Add(key,aspect);
        aspect.container = this;
        return aspect;
    }

    public T GetAspect<T>(string key = null) where T : IAspect {
        key = key ?? typeof(T).Name;
        T aspect = aspects.ContainsKey(key) ? (T)aspects[key] : default(T);
        return aspect;
    }

    public ICollection<IAspect> Aspects() { return aspects.Values; }
    #endregion
    public List<ScriptableComponent> ScriptableComponents = new List<ScriptableComponent>();
    public Action<Entity> OnMouseEnterEvent;
    public Action<Entity> OnMouseOverEvent;
    public Action<Entity> OnMouseExitEvent;
    public Action<Entity> OnMouseDownEvent;
    public Action<Entity> OnMouseUpEvent;
    public Action<Entity> OnMouseDragEvent;

    #region EventHandler Defitions
    private void OnMouseEnter() {
        //Debug.LogFormat("OnMouseEnter");
        OnMouseEnterEvent?.Invoke(this);
    }

    private void OnMouseOver() {
        //Debug.LogFormat("OnMouseOver");
        OnMouseOverEvent?.Invoke(this);
    }

    private void OnMouseExit() {
        //Debug.LogFormat("OnMouseExit");
        OnMouseExitEvent?.Invoke(this);
    }

    private void OnMouseDown() {
        //Debug.LogFormat("OnMouseClick");
        OnMouseDownEvent?.Invoke(this);
    }

    private void Awake() {
        foreach (var scriptableComponent in ScriptableComponents) {
            if (scriptableComponent is IAwake awakeComponent) {
                awakeComponent.SCAwake(this);
            }
        }
    }

    private void OnMouseUp() { OnMouseUpEvent?.Invoke(this); }

    private void OnMouseDrag() { OnMouseDragEvent?.Invoke(this); }
    #endregion

    private void OnDisable() {
        foreach (var scriptableComponent in ScriptableComponents) {
            if (scriptableComponent is IDestroy destroyComponent) {
                destroyComponent.SCDestroy(this);
            }
        }
    }

    private void Update() {
        foreach (var component in ScriptableComponents) {
            if (component is ITick tickComponent) {
                tickComponent.Tick(this);
            }

            string logString = string.Format("Entity: {0}, Stats:",this);
            var statsAspect = GetAspect<StatsAspect>();
            if (statsAspect != null) {

                foreach (var stat in statsAspect.GetStats()) {
                    if (stat.Name == "Health") {
                        logString += string.Format("Stat: {0}, Value: {1}",stat.Name,stat.Value);
                    }
                }
            }

            Debug.LogFormat(logString);
        }
    }

    private void OnValidate() {
        // Remove all null Components
        for (int i = ScriptableComponents.Count - 1; i >= 0; i--) {
            if (ScriptableComponents[i] == null) {
                ScriptableComponents.RemoveAt(i);
            }
        }
    }
}