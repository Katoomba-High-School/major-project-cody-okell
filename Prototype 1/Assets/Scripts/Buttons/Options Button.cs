using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsButton : MonoBehaviour
{

    public void GoToOptions()
    {
        SceneManager.LoadScene("Options");
    }

    public void GoToOptions2()
    {
        SceneManager.LoadScene("options2");
        
    }
}
