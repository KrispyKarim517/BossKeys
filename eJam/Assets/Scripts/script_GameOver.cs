using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class script_GameOver : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject gobj = null;
    public Text text_TextBox = null;
    public Button btn_Restart = null;
    public Button btn_Quit = null;

    [Header("Powerbar")]
    public script_MeterManagement ref_Meter = null;

    public void CheckWin()
    {
        if (ref_Meter.GetMeterValue() > .7 )
        {
            text_TextBox.text = "Winner Winner Chicken Dinner (literally)";
        }
        else
        {
            text_TextBox.text = "More like Beni-hasbeen AYO!!!";
        }
    }

    public void Display()
    {
        gobj.SetActive(true);
        text_TextBox.gameObject.SetActive(true);
        btn_Restart.gameObject.SetActive(true);
        btn_Quit.gameObject.SetActive(true);
    }
}
