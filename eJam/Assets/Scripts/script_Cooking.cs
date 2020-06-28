using System.Linq;
using UnityEngine;

/*
    AUTHOR: Nichole Wong
    STATUS: Incomplete
    PURPOSE: Script that controls cooking events.
    DEPENDENCIES: script_FoodScript
    ---------------------------------------------
    LAST UPDATED: 6/28 @ 9:05AM (Nichole)
*/

public class script_Cooking : MonoBehaviour
{
   /*
       Initialize the following:
           - Sprites for raw, cooked, and burnt steak / chicken.
           - Floats for the cooking / burning time limits for steaks and chickens
           - Reference to the script that we'll call for the success event
           - Time step that represents how often we want to update the timer 
           in script_FoodScript
   */
   [SerializeField]
   private Sprite sprite_SteakRaw, sprite_SteakCooked, sprite_SteakBurnt = null;
   
   [SerializeField]
   private Sprite sprite_ChickenRaw, sprite_ChickenCooked, sprite_ChickenBurnt = null;
   
   [Header("script_FoodScript Reference")]
   [SerializeField] private script_FoodScript ref_FoodScript = null;
   
   [Header("Steak Cook Time")]
   [SerializeField][MinAttribute(0f)] private float float_SteakCookTime = 0f;
   [Header("Steak Burn Time")]
   [SerializeField][MinAttribute(0f)] private float float_SteakBurnTime = 0f;
   
   [Header("Chicken Cook Time")]
   [SerializeField][MinAttribute(0f)] private float float_ChickenCookTime = 0f;
   [Header("Chicken Burn Time")]
   [SerializeField][MinAttribute(0f)] private float float_ChickenBurnTime = 0f;
   
   [Header("Wait Time")]
   [SerializeField][MinAttribute(.1f)] private float float_TimeStep = .1f;
    /*
        Ensure that the following conditions are met:
            - Reference to script_FoodScript is not null
            - If any Sprite variable is not assigned, it's default value is null
            (done to suppress warnings that appear in the Console)
    */
    private void Start()
    {
        Debug.Assert(ref_FoodScript != null, "script_Cooking: ref_FoodScript should not be null.");
        if (!sprite_SteakRaw) sprite_SteakRaw = null;
        if (!sprite_SteakCooked) sprite_SteakCooked = null;
        if (!sprite_SteakBurnt) sprite_SteakBurnt = null;
        if (!sprite_ChickenRaw) sprite_ChickenRaw = null;
        if (!sprite_ChickenCooked) sprite_ChickenCooked = null;
        if (!sprite_ChickenBurnt) sprite_ChickenBurnt = null;
    }
    
    /*
        PURPOSE: Listens for a successful command entry and starts the grilling event.
        INPUT: String representing a command (ex. "Cook steak.")
        OUTPUT: None
        ASSUMPTIONS:
        - Input string is not capitalized.
        - ref_FoodScript is not null.
        - This will be connected to the appropriate command in the Matcher Object
    */
    public void CorrectCookMatchListener (string str_command)
    {
        // Grab the last string in command (should be protein) and capitalize every character
        string str_target = str_command.Split().Last().ToUpper(); 
        Debug.Log("Received command: " + str_target);
        // Check which food we are cooking
        switch (str_target)
        {
            case "STEAK":
                SetFoodSettings(sprite_SteakRaw, sprite_SteakCooked, sprite_SteakBurnt, float_SteakCookTime, float_SteakBurnTime);
                break;
            case "CHICKEN":
                SetFoodSettings(sprite_ChickenRaw, sprite_ChickenCooked, sprite_ChickenBurnt, float_ChickenCookTime, float_ChickenBurnTime);
                break;
        }
        
        // Ensure that the values for ref_FoodScript's private variables are updated
        // (because they are used inside the loop)
        ref_FoodScript.SetCookingStatus();
        
        // Calls the function "StartCooking" every float_TimeStep second(s)
        // The function won't get called every frame, but this will simulate the effect of 
        // calling Update. 
        ref_FoodScript.InvokeRepeating("StartCooking", 0, float_TimeStep);
    }
    
    /*
        PURPOSE: Set the sprites and cooking times in script_FoodScript for the appropriate cooking event
        INPUT: Sprite, Sprite, Sprite, Float, Float, Float
        OUTPUT: None 
    */
    private void SetFoodSettings(Sprite sprite_FoodRaw, Sprite sprite_FoodCooked, Sprite sprite_FoodBurnt, float float_FoodCookTime, float float_FoodBurnTime)
    {
        ref_FoodScript.sprite_raw = sprite_FoodRaw;
        ref_FoodScript.sprite_cooked = sprite_FoodCooked;
        ref_FoodScript.sprite_burnt = sprite_FoodBurnt;
        ref_FoodScript.float_TimeTilCooked = float_FoodCookTime;
        ref_FoodScript.float_TimeTilBurnt = float_FoodBurnTime;
    }
}