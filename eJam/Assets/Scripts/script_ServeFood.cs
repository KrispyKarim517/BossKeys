using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class script_ServeFood : MonoBehaviour
{
    public GameObject gobj_CookedSteak;
    public GameObject gobj_BurntSteak;
    public GameObject gobj_CookedChicken;
    public GameObject gobj_BurntChicken;
    private bool burntVersion;

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
