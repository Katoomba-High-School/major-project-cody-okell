using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressureplate : MonoBehaviour
{

    public GameTrigger GameTrigger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Selectable")
        {
            GameTrigger.Trigger(this.gameObject, new TriggerEventArgs("Enter"));
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Selectable")
        {
            GameTrigger.Trigger(this.gameObject, new TriggerEventArgs("Leave"));
        }
    }

}
