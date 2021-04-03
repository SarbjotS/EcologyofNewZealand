using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Dropdown ResolutionDropdown;

    Resolution[] resolutions; //Array to get all possible resolutions available on PC
    private void Start()
    {
        resolutions = Screen.resolutions; //Getting resolutions
        ResolutionDropdown.ClearOptions();

        List<string> options = new List<string>(); //Create a list of options, to convert from string

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++) {
            string option = resolutions[i].width + "x" + resolutions[i].height; //get resolutions
            options.Add(option);  //Add string option to List of options
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                
            {
                currentResolutionIndex = i;
            }
        }
        ResolutionDropdown.AddOptions(options); //add List variable to 
        ResolutionDropdown.value = currentResolutionIndex;
        ResolutionDropdown.RefreshShownValue();
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume); //Set master volume from slider input
    }

    public void SetQuality (int QualityIndex)
    {
        QualitySettings.SetQualityLevel(QualityIndex); //Setting quality level (0 being low, 2 being high) 
    }

    public void SetFullScreen(bool fullScreened)
    {
        Screen.fullScreen = fullScreened; //True if full screen, false if not
    }

    public void setResolution (int resolutionIndex)
    {
        Resolution r = resolutions[resolutionIndex];
        Screen.SetResolution(r.width, r.height, Screen.fullScreen);
    }
}
