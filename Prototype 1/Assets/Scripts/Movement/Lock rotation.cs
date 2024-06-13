using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Lockrotation : MonoBehaviour
{
    public EventTrigger trigger;

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0, 0, 0);
    }

    
        


    // Update is called once per frame
    void Update()
    {

        Rigidbody rb = GetComponent<Rigidbody>();

        rb.freezeRotation = true;
    }
}
