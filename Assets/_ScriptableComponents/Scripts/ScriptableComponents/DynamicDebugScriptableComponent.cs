using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum DynamicDebugTextMessageType {
    Default,
    Stats // Requires Entity to have Stats Aspect
}

[Serializable]
public class DynamicDebugTextMessage {
    public DynamicDebugTextMessageType MessageType;
    public string Message = "{0}";
    public Color TextColor = Color.white;
}

[CreateAssetMenu(fileName = "New DynamicDebugScriptableComponent",menuName = "ScriptableComponents/Components/DynamicDebug")]
[Serializable]
public class DynamicDebugScriptableComponent : ScriptableComponent,ITick, IAwake {
    public bool Billboarding = true;
    public float TextSize = 5;
    public Vector3 Offset = Vector3.up;
    public List<DynamicDebugTextMessage> Messages = new List<DynamicDebugTextMessage>();

    private bool editorDirty;
    private float oldTextSize;
    private Vector3 oldOffset;
    private bool oldBillboarding;
    public void SCAwake(Entity inputEntity) {
        
        oldTextSize = TextSize;
        oldOffset = Offset;
        foreach (var message in Messages) {
            string colorString = "<color=#" + ColorUtility.ToHtmlStringRGB(message.TextColor) + ">";

            switch (message.MessageType) {

                case DynamicDebugTextMessageType.Default:
                    inputEntity.AddDebugItem(() => { return string.Format(colorString + message.Message + "</color>",inputEntity.gameObject.name); });
                    break;
                case DynamicDebugTextMessageType.Stats:
                   

                    inputEntity.AddDebugItem(() => {
                        StatsAspect inputEntityStatsAspect = inputEntity.GetAspect<StatsAspect>();
                        //Debug.LogFormat("From DDT Debug Item. Stats: {0}", inputEntity.GetAspect<StatsAspect>().GetStats().Count);
                        string returnString = "Stats: \n";
                        if (inputEntityStatsAspect != null) {
                            foreach (var inputStat in inputEntityStatsAspect.GetStats()) {
                                returnString += string.Format("{0}: {1} \n",inputStat.Name,inputStat.Value);
                            }
                        } else {
                            returnString += "None";
                        }

                        return returnString;
                    });

                    break;
                default: throw new ArgumentOutOfRangeException();
            }
        }

        UpdateValues(inputEntity);
        inputEntity.Debugging(true);
    }
    

    private void UpdateValues(Entity inputEntity) {
        inputEntity.SetDebugTextSize(TextSize);
        inputEntity.SetDebugOffset(Offset);
        if (inputEntity.TryGetComponent(out DynamicDebugText targetDebugText)) {
            targetDebugText.BillBoardText = Billboarding;
        }
    }

    private void OnValidate() {
        if (Application.isPlaying) {
            if (oldTextSize != TextSize) {
                editorDirty = true;
                oldTextSize = TextSize;
            }

            if (oldOffset != Offset) {
                editorDirty = true;
                oldOffset = Offset;
            }

            if (oldBillboarding != Billboarding) {
                editorDirty = true;
                oldBillboarding = Billboarding;
            }
        }
    }

    public void Tick(Entity inputEntity) {
        if (editorDirty) {
            Debug.LogFormat("Editor dirty! Updating DDT!");
            UpdateValues(inputEntity);
            editorDirty = false;
        }
    }

    
}