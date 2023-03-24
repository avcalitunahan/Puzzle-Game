using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public GameObject PanelSettings;
    public GameObject Panel1;

    public void PlayGame()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
   

    public void QuitGame()
    {
        
         Application.Quit();
    }



    public void PanelVisible()
    {
        PanelSettings.gameObject.SetActive(true);
        Panel1.gameObject.SetActive(false);
    }

    public void PanelVisible2()
    {
        PanelSettings.gameObject.SetActive(false);
        Panel1.gameObject.SetActive(true);
    }




}
