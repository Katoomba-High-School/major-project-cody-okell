using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;

public class MouseMoveScript : MonoBehaviour
{
    public bool IsSpring;


    // Update is called once per frame
    void Update()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        SpringJoint joint = GetComponent<SpringJoint>();
        Rigidbody rb = GetComponent<Rigidbody>();   
        Transform transform = GetComponent<Transform>();

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                IsSpring = true;
            }
                
            
        }


        if (IsSpring)
            {
              Vector3 mouse = Input.mousePosition;
              Ray castPoint = Camera.main.ScreenPointToRay(mouse);
              if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
              {
                transform.position = hit.point;
                hit.point = Input.mousePosition;
              }

                joint.maxDistance = 1;
                joint.minDistance = 1;
                joint.spring = 5;
                joint.damper = 1;
        }
        
           

        if (Input.GetMouseButtonUp(0))
        {
            IsSpring = false;           
        }
        if (!IsSpring)
        {
            joint.maxDistance = 0;
            joint.minDistance = 0;
            joint.spring = 0;
            joint.damper = 0;
        }
        //connect the click to the game object rather than every object.
    }
}
