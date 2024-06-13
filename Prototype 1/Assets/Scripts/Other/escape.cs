using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Escape : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;
    public bool isGamePaused = false;
    public bool isGameActive = true;
    GameObject btn_Resume;

    public void Start()
    {
       // PauseMenu.gameObject.SetActive(true);
        
        var btn_resume = GameObject.Find("Resume");
        //btn_resume.GetComponent<>
      
        //GameObject.FindObjectsOfType(typeof(MonoBehaviour)); 
        GameObject.FindGameObjectsWithTag("Clickable");  //tag search
            
        
        
    }

    public void Btn_ResumeClick()
    {
        isGamePaused = false;
        ContinueGame();
    }


    public void PauseGame()
    {
        PauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void ContinueGame()
    {
        PauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
    
    }

    // Update is called once per frame
    public void Update()
    {
 
        if (Input.GetKeyDown(KeyCode.Escape) && isGameActive)
        {

            if(isGamePaused)
            {
                ContinueGame();
            }
            else
            {
                PauseGame();
            }

            isGamePaused = !isGamePaused;


            Debug.Log("HELLO !");
        }

        if (isGamePaused)
        {
            
            GameObject.FindGameObjectsWithTag("Clickable");

        }
        

    }

    public void Restart()
    {
        SceneManager.LoadScene("MainGame");
    }

    






}
