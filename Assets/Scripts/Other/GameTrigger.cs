using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;



public class TriggerEventArgs : EventArgs
{
    public string Tag { get; private set; }

    public TriggerEventArgs(string tag)
    {
        Tag = tag;
    }
}


public class GameTrigger : MonoBehaviour
{
    public delegate void TriggerEventHandler(object sender, TriggerEventArgs args);

    public event TriggerEventHandler OnTrigger;
    public void Trigger(GameObject sender, TriggerEventArgs args)
    {
        OnTrigger?.Invoke(sender, args);
    }
   

}
