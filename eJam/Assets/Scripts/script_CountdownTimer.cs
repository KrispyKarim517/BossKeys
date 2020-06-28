using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class script_CountdownTimer : MonoBehaviour
{
    private float float_timer;
    private float float_backgroundtimer;
    [SerializeField] private Text text_displaytimer = null;
    // Start is called before the first frame update
    void Start()
    {
        float_timer = 10;
        text_displaytimer.text = float_timer.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        float_backgroundtimer += Time.deltaTime;
        if (float_timer == 0)
        {
            float_timer = 10;
            text_displaytimer.text = float_timer.ToString();
            float_backgroundtimer = 0;
        }
        else if (float_backgroundtimer >= 1)
        {
            float_timer -= 1;
            text_displaytimer.text = float_timer.ToString();
            float_backgroundtimer = 0;
        }
    }
}
