using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FileManager : MonoBehaviour
{
    string path;
    public RawImage image;

    public GameObject DialogWindow;
    public GameObject PlayerNameWindow;
    public InputField _url;
    public GameObject urlPanel;

   

    public void OpenFileExplorer()
    {
        path = EditorUtility.OpenFilePanel("Show all images (.png)", "", "png");
        StartCoroutine(GetTexture());

        DialogWindow.gameObject.SetActive(false);
        PlayerNameWindow.gameObject.SetActive(true);



    }

    IEnumerator GetTexture()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture("file:///" + path);
        yield return www.SendWebRequest();



        {
            Texture myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            image.texture = myTexture;
        }



    }


    public void ButtonClick()
    {
        StartCoroutine(GetImageFromWeb(_url.text));
        urlPanel.gameObject.SetActive(false);

        PlayerNameWindow?.SetActive(true);

    }

    IEnumerator GetImageFromWeb(string x)
    {
        UnityWebRequest reg = UnityWebRequestTexture.GetTexture(x);
        yield return reg.SendWebRequest();

        Texture img = ((DownloadHandlerTexture)reg.downloadHandler).texture;
        image.texture = img;




    }


    public void UrlButton()
    {
        DialogWindow.gameObject.SetActive(false);
        urlPanel.gameObject.SetActive(true);
    }





    public void QuitGame()
    {
         Application.Quit();
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("SampleScene");
    }

    



}






