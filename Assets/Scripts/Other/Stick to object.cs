using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Rigidbody rb;
    public GameTrigger GameTrigger;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Selectable")
        {
            rb.isKinematic = false;

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
