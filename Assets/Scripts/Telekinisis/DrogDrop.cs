using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour
{
    
    Slider slider;
    Rigidbody Rigidbody;
    /// <summary>
    /// Speed in which the object moves forwards and backwards.
    /// </summary>
    public float scrollSpeed = 0.2f;
    public Transform cylinder;
    private Vector3 _mousePosition;
    private Vector3 _offset;
    public float distanceFromCamera;
    private Transform Cylinder;
    
    
     private void Start()
     {
         Rigidbody = GetComponent<Rigidbody>();
         slider = GetComponent<Slider>();
     }

     private void OnCollisionEnter(Collision collision)
     {
         if (collision != null)
         {

         }
         Debug.Log("collision");
     }

     public Vector3 GetObjectScreenPos() 
     {
         return Camera.main.WorldToScreenPoint(transform.position);
     }

     private void OnMouseDown()
     {
         _mousePosition = Input.mousePosition - GetObjectScreenPos();

     }

     private void OnMouseUp()
     {
        Rigidbody.velocity = Vector3.zero;
         Debug.Log($"{Rigidbody.velocity}");

     }

     private void OnMouseDrag()
     {
         transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - (_mousePosition + _offset));
     }

     void Update()
     {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            // minimap.orthographicSize++;
            _offset += new Vector3(0, 0, scrollSpeed);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            // minimap.orthographicSize--;
            _offset += new Vector3(0, 0, -scrollSpeed);
        }

        
     }




    public void changeSliderValue()
    {
        //slider = 
        
        /*if (slider.value > 0f)
        {
            scrollSpeed = slider.value;
        }*/

        
    }
}
