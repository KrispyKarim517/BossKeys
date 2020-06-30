using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class script_PauseMenu : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject gobj_BackgroundImage = null;
    public Button btn_Resume = null;
    public Button btn_Quit = null;


    private bool bool_IsPaused = false;

    // Update is called once per frame
    public void EscapeKeyPressed()
    {
        if (bool_IsPaused)
            ResumeGame();
        else
            PauseGame();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        //this.gameObject.SetActive(true);
        gobj_BackgroundImage.SetActive(true);
        btn_Resume.gameObject.SetActive(true);
        btn_Quit.gameObject.SetActive(true);
        bool_IsPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        //this.gameObject.SetActive(false);
        gobj_BackgroundImage.SetActive(false);
        btn_Resume.gameObject.SetActive(false);
        btn_Quit.gameObject.SetActive(false);
        bool_IsPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
