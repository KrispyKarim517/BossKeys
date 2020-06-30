using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class script_CommandSequencer : MonoBehaviour
{
    [Header("Matching Object")]
    public script_CommandMatchingScript customType_Matcher = null;

    [Header("Food Object")]
    public script_ServeFood food = null;

    [Header("Thought Bubbles")]
    public GameObject gobj_CookedSteakBubble;
    public GameObject gobj_BurntSteakBubble;
    public GameObject gobj_CookedChickenBubble;
    public GameObject gobj_BurntChickenBubble;

    private List<string> list_AllJokes = new List<string>()
                                        {
                                            "STEAK PUNS ARE PRETTY RARE",
                                            "INSULTING MY NOODLES IS PRETTY LO MEIN",
                                            "THE RIGHT SAUCE IS TERIYA KEY", //Does this one make sense?
                                            "I FRIED THIS RICE NOT THE SHRIMP",
                                            "CHICKEN DOESNT NEED SEASONING",
                                            "THIS CHICKEN CROSSED THE WRONG ROAD",
                                        };
    private List<string> list_OnlyNewJokes;

    private Queue<string> queue_Commands = new Queue<string>();
    
    private System.Random random_RandomIndexGenerator = new System.Random();

    private bool bool_ServedSteak = false;

    // Start is called before the first frame update
    void Start()
    {
        list_OnlyNewJokes =  list_AllJokes.ToList();
    }

    public string GetNextCommand()
    {
        if (queue_Commands.Count != 0)
        {
            return queue_Commands.Dequeue();
        }
        else
        {
            return GenerateJoke();
        }
    }

    public void ReadyCommand()
    {
        customType_Matcher.SetNewCommand(GetNextCommand());
    }

    public void PushCommand(string str_new_command)
    {
        queue_Commands.Enqueue(str_new_command);
    }

    public string GenerateJoke()
    {
        if (list_OnlyNewJokes.Count == 0)
            list_OnlyNewJokes = list_AllJokes.ToList();
        
        int int_random_index = random_RandomIndexGenerator.Next(list_OnlyNewJokes.Count);
        string str_new_joke = list_OnlyNewJokes[int_random_index];
        list_OnlyNewJokes.RemoveAt(int_random_index);
        return str_new_joke;
    }

    public void GrabFoodOffGrill()
    {
        if (!bool_ServedSteak)
        {
            if (food.isBurnt())
            {
                gobj_BurntSteakBubble.SetActive(true);
            }
            else
            {
                gobj_CookedSteakBubble.SetActive(true);
            }
        }
        else
        {
            if (food.isBurnt())
            {
                gobj_BurntChickenBubble.SetActive(true);
            }
            else
            {
                gobj_CookedChickenBubble.SetActive(true);
            }
        }
    }

    public void QueueGrabFoodOffGrill()
    {
        if (!bool_ServedSteak)
        {
            PushCommand("GRAB STEAK");
        }
        else
        {
            PushCommand("GRAB CHICKEN");
        }
    }
}