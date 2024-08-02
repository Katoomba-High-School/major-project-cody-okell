using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movingblocks : MonoBehaviour
{
    float time = 4f;
    public AnimationCurve myCurve;
    Vector3 originalPos = new Vector3(0, 0, 0);
    Vector3 targetPos = new Vector3(0, 0, 0);
    Vector3 difference;
    public Vector3 offset = new Vector3(0, 0, 0);
    float timer = 0;
    public float seconds = 2;


    void Start()
    {
        
        originalPos = gameObject.transform.position;
        targetPos = originalPos + offset;
        
    }

    void Update()
    {
        {

            // var step = speed * Time.deltaTime;
            // gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, originalPos + offset, step);
            transform.position = new Vector3(transform.position.x, transform.position.y, myCurve.Evaluate(Time.time % myCurve.length));

            if (timer <= seconds)
                {
                    // basic timer
                    timer += Time.deltaTime;
                    // percent is a 0-1 float showing the percentage of time that has passed on our timer!
                    var percent = timer / seconds;

                    if (percent >= 1)
                    {
                        isMoving = false;
                        // IsComplete = true;
                    }

                    //transform.position = start + (difference) * percent;
                
                }
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, myCurve.Evaluate(Time.time % myCurve.length));
    }

    bool isMoving = false;
}

