using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class settingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Dropdown resolutionDropdown;

    //This array will be the resolutions available on the computer.
    Resolution[] resolutions;

    void Start()
    {
        //sets the array "resolutions" to contain the resolutions available to the computer system
        resolutions = Screen.resolutions;
        
        //Clears the placeholders on the dropdown to make room for the newly found resolutions.
        resolutionDropdown.ClearOptions();

        //This list will store the resolutions from the computer and simplify them into a format we can understand.
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        //Loops through each option in the resolutions array
        for (int i = 0; i < resolutions.Length; i++)
        {
            //writes the width and height to a string in an understandable format for each resolution.
            string option = resolutions[i].width + " X " + resolutions[i].height;
            //adds the string just made to options list
            options.Add(option);

            //if the resolution width and height is the same as the current resolution on the computer.....
            if (resolutions[i].width == Screen.currentResolution.width && 
                resolutions[i].height == Screen.currentResolution.height)
            {
                //change the resolution to its original resolution.
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    //this is called when a resolution is selected.
    public void SetResolution(int resolutionIndex)
    {
        //sets the variable "resolution" to be the currently selected resolution
        Resolution resolution = resolutions[resolutionIndex];
        //sets the resolution to be the one selected.
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    //This is called when the Volume slider is changed.
    public void SetVolume(float volume)
    {
        //Logs the value of the slider to the console to test if it works
        Debug.Log(volume);

        //This changes the value of the public audio mixer based on what the slider is set to.
        audioMixer.SetFloat("volume", volume);
    }

    //This is called when the tick box for fullscreen is either checked or unchecked.
    public void SetFullscreen(bool isFullscreen)
    {
        //Fullscreen is determined whether the variable isFullscreen is true
        Screen.fullScreen = isFullscreen;
        
    }
}