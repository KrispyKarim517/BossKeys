using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class script_MeterManagement : MonoBehaviour
{
    Image image_meter;
    private float float_maxMeter = 1f;
    private static float float_currentMeter = 0.4f;
    private static float float_timer = 0.0f;
    private static float float_waitTime = 1.0f;
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
}
