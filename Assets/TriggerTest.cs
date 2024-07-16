using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerTest : MonoBehaviour
{

    public GameTrigger GameTrigger;
    // Start is called before the first frame update

    public Vector3 offset = new Vector3(0, 0, 0);

    Vector3 originalPos = new Vector3(0, 0, 0);
    Vector3 targetPos = new Vector3(0, 0, 0);
    Vector3 difference;

    float timer = 0;
    public float seconds = 2;


    void Start()
    {
        GameTrigger.OnTrigger += GameTrigger_OnTrigger;
        originalPos = gameObject.transform.position;
        targetPos = originalPos + offset;
        //timer = seconds;
    }

    private void GameTrigger_OnTrigger(object sender, TriggerEventArgs args)
    {
        Debug.Log("dsadsa");
       
        isMoving = true;
        timer = 0;

        if (args.Tag == "Enter")
        {
            start = originalPos;
            difference = targetPos - originalPos;
        }

        if (args.Tag == "Leave")
        {
            start = transform.position;
            difference = originalPos - transform.position;
        }

    }



    bool isMoving = false;


    Vector3 start;

    // Update is called once per frame
    void Update()
    {
        if(isMoving)
        {
           // var step = speed * Time.deltaTime;
           // gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, originalPos + offset, step);


            if(timer <= seconds) {
                // basic timer
                timer += Time.deltaTime;
                // percent is a 0-1 float showing the percentage of time that has passed on our timer!
                var percent = timer / seconds;

                if(percent >= 1) 
                {
                    isMoving = false;
                  // IsComplete = true;
                }

                transform.position = start + (difference) * percent;
            }
        }
    }
}
