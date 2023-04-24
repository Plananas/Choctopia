using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsMenu;
    public GameObject mainMenu;
    public GameObject multiplayerMenu;
    

    
    //when the settings button is pressed, call this function
    public void GotoSettings()
    {
        //disable the main menu and enable the settings menu.
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
    //When the back button is pressed on the settings menu, call this function
    public void GoOffSettings()
    {
        //disable the settings menu and enable the main menu.
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    //when the multiplayer button is pressed on the main menu, call this function
    public void GotoMultiplayer()
    {
        SceneManager.LoadScene(1);
    }
    //when the back button is pressed on multiplayer menu, call this function
    public void GoOffMultiplayer()
    {
        SceneManager.LoadScene(0);
    }


    //when the quit button is pressed, call this function
    public void QuitGame()
    {
        //Quits the game, Debug logs it into the console to show this function works
        Debug.Log("Quit");
        Application.Quit();
    }

    public void LoadSinglePlayer()
    {
        //loads the sngleplayer scene
        SceneManager.LoadScene(2);
    }
}
