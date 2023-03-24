using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class SettingsMenu : MonoBehaviour
{
    public AudioMixer MainMixer;
    // Start is called before the first frame update
    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }



    public void SetQuality(int qualityIndex)
    {
         QualitySettings.SetQualityLevel(qualityIndex);
    }


    public void SetVolume(float MyExposedParam)
    {
        MainMixer.SetFloat("MyExposedParam", MyExposedParam);
    }



}
