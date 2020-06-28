using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class script_TimerScript : MonoBehaviour
{
    [Header("Timer Text Box")]
    public Text text_UIText;

    private float float_timer;
    private bool bool_counting;

    void Start()
    {
        float_timer = 0;
        bool_counting = false;
        text_UIText.text = "0";
    }

    void Update()
    {
        if(bool_counting)
        {
            float_timer += Time.deltaTime;
            int temp_int_numberForText = (int) float_timer;
            text_UIText.text = "" + temp_int_numberForText;
        }
    }

    public void StartTimer()
    {
        bool_counting = true;
    }
    public void StartTimer(string s)
    {
        bool_counting = true;
    }
    public void EndTimer()
    {
        float_timer = 0;
        bool_counting = false;
        text_UIText.text = "0";
    }
    public void EndTimer(string s)
    {
        float_timer = 0;
        bool_counting = false;
        text_UIText.text = "0";
    }
}
