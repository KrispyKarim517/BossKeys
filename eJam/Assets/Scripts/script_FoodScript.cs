using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class script_FoodScript : MonoBehaviour
{
    public float float_TimeTilCooked;
    public float float_TimeTilBurnt;

    public Sprite sprite_cooked, sprite_burnt;

    [NonSerialized]
    public bool bool_raw, bool_cooked, bool_burnt;

    private float float_timer;
    private float float_activeTime;

    private SpriteRenderer m_SpriteRenderer;

    void Start()
    {
        bool_raw = true;
        bool_cooked = bool_burnt = false;

        float_timer = 0;
        float_activeTime = float_TimeTilCooked;

        m_SpriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(!bool_burnt)
        {
            float_timer += Time.deltaTime;
            if(float_timer >= float_activeTime)
            {
                if(bool_raw)
                {
                    RawToCooked();
                }
                else if(bool_cooked)
                {
                    CookedToBurnt();
                }
            }
        }
    }

    private void RawToCooked()
    {
        bool_raw = false;
        bool_cooked = true;
        float_timer = 0;
        float_activeTime = float_TimeTilBurnt;
        m_SpriteRenderer.sprite = sprite_cooked;
    }

    private void CookedToBurnt()
    {
        bool_cooked = false;
        bool_burnt = true;
        m_SpriteRenderer.sprite = sprite_burnt;
    }

    public bool isRaw()
    {
        return bool_raw;
    }
    public bool isCooked()
    {
        return bool_cooked;
    }
    public bool isBurnt()
    {
        return bool_burnt;
    }
}
