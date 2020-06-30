using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class script_MeterManagement : MonoBehaviour
{
    Image image_meter;
    private float float_maxMeter = 1f;
    private static float float_currentMeter = 0.55f;
    private static float float_timer = 0.0f;
    private static float float_waitTime = 1.0f;

    private string[] arr_str_SupportedCommands = { "SEASON", "GET", "GRILL", "GRAB", "SERVE" };
    
    // Start is called before the first frame update
    void Start()
    {
        image_meter = GetComponent<Image>();
        image_meter.fillAmount = float_currentMeter;
    }

    // Update is called once per frame
    void Update()
    {
        float_timer += Time.deltaTime;
        if (float_timer >= float_waitTime)
        {
            float_currentMeter -= 0.01f;
            image_meter.fillAmount = float_currentMeter/float_maxMeter;
            float_timer = 0;
        }
    }

    public void gain_Meter(string bonus)
    {
        string str_command_first_word = bonus.Split()[0];
        if (arr_str_SupportedCommands.Contains(str_command_first_word))
        {
            float_currentMeter += .075f;
            if (float_currentMeter > 1f)
                float_currentMeter = 1f;
        }
        else
        {
            float_currentMeter += .15f;
            if (float_currentMeter > 1f)
                float_currentMeter = 1f;
        }
    }
}
