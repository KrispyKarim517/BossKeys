using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class script_ServeFood : MonoBehaviour
{
    [Header("Sequencer Object")]
    public script_CommandSequencer gobj_Sequencer;

    [Header("Food Sprites")]
    public GameObject gobj_CookedSteak;
    public GameObject gobj_BurntSteak;
    public GameObject gobj_CookedChicken;
    public GameObject gobj_BurntChicken;
    private bool burntVersion;

    [Header("Thought Bubbles")]
    public GameObject gobj_CookedSteakBubble;
    public GameObject gobj_BurntSteakBubble;
    public GameObject gobj_CookedChickenBubble;
    public GameObject gobj_BurntChickenBubble;

    public void EnableCookedSteak()
    {
        gobj_CookedSteak.SetActive(true);
    }

    public void EnableBurntSteak()
    {
        gobj_BurntSteak.SetActive(true);
    }
    public void EnableCookedChicken()
    {
        gobj_CookedSteak.SetActive(true);
    }

    public void EnableBurntChicken()
    {
        gobj_BurntSteak.SetActive(true);
    }

    public void SwitchToBurnt()
    {
        burntVersion = true;
    }

    public void ServeFoodListener(string str_CommandText)
    {
        string str_TempFood = str_CommandText.Split().Last();
        if (str_TempFood == "STEAK")
        {
            if (burntVersion)
            {
                EnableBurntSteak();
            }
            else
            {
                EnableCookedSteak();
            }
            gobj_Sequencer.PushCommand("GET CHICKEN");
            gobj_Sequencer.ReadyCommand();
        }
        else
        {
            if (burntVersion)
            {
                EnableBurntChicken();
            }
            else
            {
                EnableCookedChicken();
            }
        }
    }
}
