using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

/*
    ORIGINAL AUTHOR: RYAN GREEN
    EDITED BY: Nichole Wong
    ---------------------------------------------
    LAST UPDATED: 6/28 @ 9:05AM (Nichole)
        - Added sprite variables to include the no-plate raw sprites
        - Added function SetCookingStatus()
        - Added function StartCooking()
        - Added dependency: script_Cooking.cs
        - Added component requirement: SpriteRenderer
*/

[RequireComponent(typeof(SpriteRenderer))]
public class script_FoodScript : MonoBehaviour
{
    public float float_TimeTilCooked;
    public float float_TimeTilBurnt;

    [Header("Cooked Food Event")]
    public UnityEvent event_CookedFoodEvent = new UnityEvent();

    [Header("Burnt Food Event")]
    public UnityEvent event_BurntFoodEvent = new UnityEvent();

    public Sprite sprite_raw, sprite_cooked, sprite_burnt;

    [NonSerialized]
    public bool bool_raw, bool_cooked, bool_burnt, bool_cooking;

    private float float_timer;
    private float float_activeTime;

    private SpriteRenderer m_SpriteRenderer;


    void Start()
    {
        bool_raw = true;
        bool_cooked = bool_burnt = bool_cooking = false;

        float_timer = 0;
        float_activeTime = float_TimeTilCooked;

        m_SpriteRenderer = this.GetComponent<SpriteRenderer>();
        m_SpriteRenderer.sprite = sprite_raw;
    }

    void Update()
    {
        if(bool_cooking)
        {
            //Debug.Log(bool_cooking);
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
    }
    
    /*
        INPUT: None
        OUTPUT: None
        PURPOSE: Updates the values of private variables float_active & float_activeTime
    */
    public void SetCookingStatus()
    {
        float_activeTime = float_TimeTilCooked;
        m_SpriteRenderer.sprite = sprite_raw;
    }

    /*
        INPUT: None
        OUTPUT: None 
        PURPOSE: Starts the grilling cycle
        
        Instead of calling Update(), I thought it'd be better to have StartCooking be 
        a separate function so that it's easier to trigger (unless there is a method for 
        triggering Update).
    */
    public void StartCooking()
    {
        bool_cooking = true;
        Debug.Log("CHICKEEEEEEEEEEEEEEEEEN");
    }

    private void RawToCooked()
    {
        bool_raw = false;
        bool_cooked = true;
        float_timer = 0;
        float_activeTime = float_TimeTilBurnt;
        m_SpriteRenderer.sprite = sprite_cooked;
        event_CookedFoodEvent.Invoke();
        Debug.Log("Steak is cooked");

    }

    private void CookedToBurnt()
    {
        bool_cooked = false;
        bool_burnt = true;
        m_SpriteRenderer.sprite = sprite_burnt;
        event_BurntFoodEvent.Invoke();
        Debug.Log("Steak is burnt");
    }

    public void StopCooking(string _)
    {
        m_SpriteRenderer.sprite = null;
        //Debug.Log("Hello There");
        bool_cooking = false;
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
