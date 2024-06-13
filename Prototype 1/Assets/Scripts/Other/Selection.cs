using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class Selection : MonoBehaviour
{
    public Material highlightMaterial;
    public Material selectionMaterial;

    private Material originalMaterial;
    private Transform highlight;
    private Transform selection;
    private RaycastHit raycastHit;

    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        /*Ray ray2 = Camera.main.ScreenPointToRay(!Input.GetMouseButton(mouse0));
        RaycastHit hit2;*/


        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.CompareTag("Selectable"))
            {
                if (highlight == null && selection == null)
                {
                    highlight = hit.transform;
                    originalMaterial = hit.transform.GetComponent<MeshRenderer>().sharedMaterial;
                    highlight.GetComponent<MeshRenderer>().sharedMaterial = highlightMaterial;
                }
            }
            else
            {
                ResetHighlight();
            }
        }
        else
        {
            ResetHighlight();
        }


        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (highlight != null)
            {
                selection = highlight;
                selection.GetComponent<MeshRenderer>().sharedMaterial = selectionMaterial;
            }

        }
        else
        {
            if (selection != null)
            {
                selection = null;
            }
        }
    
}
        public void ResetHighlight()
        {
            if (highlight != null && selection == null)
            {
                highlight.GetComponent<MeshRenderer>().sharedMaterial = originalMaterial;
                highlight = null;
            }
        }

        
    }
