using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Vector3 jump;
    public float jumpForce = 2;

    public bool isGrounded;
    Rigidbody rb;
    GameObject Player;
    public float playerSetX;
    public float playerSetY;
    public float playerSetZ;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(playerSetX, playerSetY, playerSetZ);
        //GetComponent<GameObject>();
        //jump = new Vector3 (0,jumpForce,0);
        //GetComponent<Rigidbody>();
        //jump = new Vector3(0, jumpForce, 0);
    }



    void OnCollisionStay()
    {
        isGrounded = true;
    }

    private void OnCollisionExit()
    {
        isGrounded = false;
    }
    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                transform.position += new Vector3(playerSetX, jumpForce, playerSetZ);
            }
            
            /*if (Input.GetKeyDown(KeyCode.Space) && isGrounded) 
            {

                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }*/

        }

    }
}
