using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class script_CommandSequencer : MonoBehaviour
{
    [Header("Matching Object")]
    public script_CommandMatchingScript customType_Matcher = null;


    private List<string> list_AllJokes = new List<string>()
                                        {
                                            "STEAK PUNS ARE PRETTY RARE",
                                            //"INSULTING MY NOODLES IS PRETTY LO MEIN",
                                            "THE RIGHT SAUCE IS TERIYA KEY", //Does this one make sense?
                                            "I FRIED THIS RICE NOT THE SHRIMP",
                                            "CHICKEN DOESNT NEED SEASONING",
                                            //"THIS CHICKEN CROSSED THE WRONG ROAD",
                                        };
    private List<string> list_OnlyNewJokes;

    private Queue<string> queue_Commands = new Queue<string>();
    
    private System.Random random_RandomIndexGenerator = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        list_OnlyNewJokes =  list_AllJokes.ToList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetNextCommand()
    {
        if (queue_Commands.Count != 0)
            return queue_Commands.Dequeue();
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
        PushCommand("GRAB STEAK");
    }
}
