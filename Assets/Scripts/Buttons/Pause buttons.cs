using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pausebuttons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       // OnButtonClick.
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void Restart()
    {
        SceneManager.LoadScene("MainGame");
        Debug.Log("restarted");
    }

    

    public void Quit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
