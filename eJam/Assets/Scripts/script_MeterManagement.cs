using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

/*
    ORIGINAL AUTHOR: Unknown
    EDITED BY: Nichole Wong
    ---------------------------------------------
    LAST UPDATED: 7/3 @ 9:25AM (Nichole)
        - Added feature where the UI bar changes colors 
        depending on the fill amount
*/

public class script_MeterManagement : MonoBehaviour
{
    [Header("Food Objects")]
    public script_FoodScript ref_Food = null;

    Image image_meter;
    private float float_maxMeter = 1f;
    private static float float_currentMeter = 0.4f;
    private static float float_timer = 0.0f;
    private static float float_waitTime = 1.0f;

    //private const float float_PointValue = 0.075f;
    private string[] arr_str_SupportedCommands = { "SEASON", "GET", "GRILL", "GRAB", "SERVE" };
    
    // Gradiant for the UI bar 
    [SerializeField] private Gradient gradient_UIBarGradiant = new Gradient();

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
        image_meter.color = gradient_UIBarGradiant.Evaluate(float_currentMeter/float_maxMeter);
    }

    public void gain_Meter(string bonus)
    {
        string str_command_first_word = bonus.Split()[0];
        if (arr_str_SupportedCommands.Contains(str_command_first_word))
        {
            float float_temp_points = 0.075f;
            if (str_command_first_word == "SERVE")
                float_temp_points = ref_Food.isBurnt() ? 0f : 0.075f;
            float_currentMeter += float_temp_points;
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

    public float GetMeterValue()
    {
        return float_currentMeter;
    }
}
