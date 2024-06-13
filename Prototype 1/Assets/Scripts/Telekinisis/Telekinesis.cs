using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;

public class Telekinesis : MonoBehaviour
{
    private const bool V = false;
    public float speed;
    private Vector2 mouseClick;
    public float rotation;
    private Vector3 mousePos;
    public float velocity;

    private bool IsTelekinesis = false;
    //private GameObject Target = null;


    private Vector3 screenPoint;
    private Vector3 offset;


    public void OnMouseCilck(InputAction.CallbackContext context)
     {
        mouseClick = context.ReadValue<Vector2>();
        
     }



    // Start is called before the first frame update

    void OnMouseDrag()
    {

        if (IsTelekinesis)
        {

            var rb = gameObject.GetComponent<Rigidbody>();

            float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

            //gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
           var target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));

           var dif = target - gameObject.transform.position;


            dif = dif.normalized;
           
            rb.velocity = dif * 30;
                    
            rb.AddForceAtPosition(mousePos, current, ForceMode.Force);
            rb.AddRelativeForce(mousePos * 0, ForceMode.VelocityChange);

            rb.AddForce((Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized * 0, ForceMode.Impulse);
            

            if (target != mousePos)
            {
                
                
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                



                if (target != mousePos)
                {
                    rb.velocity = dif * 30;
                    rb.angularVelocity = dif * 30;
                    rb.AddRelativeForce(rb.velocity * 0, ForceMode.VelocityChange);

                }
            }
        }
    }

    Vector3 current = Vector3.zero;
    // Update is called once per frame
    void Update()
    {

        Rigidbody rb = GetComponent<Rigidbody>();
     //   Debug.Log(IsTelekinesis);



        if (Input.GetMouseButtonUp(0))
        {
            if (!IsTelekinesis)
            {
                rb.useGravity = true;
                IsTelekinesis = false;
                //Target = null;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
               

               IsTelekinesis = !IsTelekinesis;
               //Target = hit.transform.gameObject;
               current = hit.transform.position;
               // Toggles the gravity
               rb.useGravity = IsTelekinesis;


            }
            
            
        }

        
    }

}

