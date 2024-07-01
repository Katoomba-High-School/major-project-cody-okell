using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop2 : MonoBehaviour
{
    private Vector3 mousePosition;
    private Rigidbody Rigidbody;
    public float scrollSpeed = 0.2f;
    private Vector3 _offset;
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    private Vector3 GetObjectScreenPos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        // Gets the intital mouse position in screen space.
        mousePosition = Input.mousePosition - GetObjectScreenPos();
    }

    private void OnMouseDrag()
    {
        // Convert difference between mouse and object to world position (Gets the distance).
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);

        // Take the difference between current object position and targeted screen position.
        // Create a veocity using the diffence.
        Rigidbody.velocity = (pos - transform.position) * 10;
    }

    private void OnMouseUp()
    {
        // Rigidbody.velocity = Vector3.zero;
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

}


