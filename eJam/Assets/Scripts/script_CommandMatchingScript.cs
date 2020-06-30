using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.Events;
using System.Runtime.InteropServices;
using System.Linq;

[System.Serializable]
public class CommandEvent : UnityEvent<string>
{
}


public class script_CommandMatchingScript : MonoBehaviour
{
    [Header("Command Sequencer")]
    [SerializeField] private script_CommandSequencer gobj_commandSequencer = null;

    [Header("Command Text Box")]
    [SerializeField] private Text text_CommandTextBox = null;

    [Header("Object with InputText Script")]
    [SerializeField] private script_InputText gobj_InputText = null;

    [Header("Delay after Incorrect Input")]
    [SerializeField] private float float_IncorrectInputDelay = 0f;
    private static WaitForSeconds wait_IncorrectInputPause;

    [Header("Command Listeners")]
    public CommandEvent event_SEASON = new CommandEvent();
    public CommandEvent event_GET = new CommandEvent();
    public CommandEvent event_GRILL = new CommandEvent();
    public CommandEvent event_GRAB = new CommandEvent();
    public CommandEvent event_SERVE = new CommandEvent();
    public CommandEvent event_BONUS = new CommandEvent();

    private string str_CommandToMatch;

    // Start is called before the first frame update
    void Start()
    {
        SetNewCommand("GET STEAK");
        wait_IncorrectInputPause = new WaitForSeconds(float_IncorrectInputDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetNewCommand(string new_command)
    {
        str_CommandToMatch = new_command;
        text_CommandTextBox.text = str_CommandToMatch;
        gobj_InputText.ClearCurrentInput();
    }

    public void ChangeTextColors(string str_current_input)
    {
        text_CommandTextBox.text = "";
        gobj_InputText.ResetBackspaceCount();
        int int_command_str_index = 0;
        for (int i = 0; i < str_current_input.Length; ++i)
        {
            if ((int_command_str_index >= str_CommandToMatch.Length) || (str_current_input[i] != str_CommandToMatch[int_command_str_index]))
            {
                text_CommandTextBox.text += GenBadCharacter(str_current_input[i]);
                gobj_InputText.IncrementBackspaces();
            }
            else
            {
                text_CommandTextBox.text += GenGoodCharacter(str_current_input[i]);
                ++int_command_str_index;
            }
        }
        while (int_command_str_index < str_CommandToMatch.Length)
        {
            text_CommandTextBox.text += str_CommandToMatch[int_command_str_index];
            ++int_command_str_index;
        }
    }

    public void ValidKeyPressListener()
    {
        ChangeTextColors(gobj_InputText.GetCurrentInput());
    }

    public void ReturnKeyPressLister()
    {
        string str_temp_final_input = gobj_InputText.GetFinalInput();
        
        if (str_temp_final_input == str_CommandToMatch)
        {
            switch (str_temp_final_input.Split()[0])
            {
                case "GET":
                    Debug.Log("Successful GET match");
                    event_GET.Invoke(str_temp_final_input);
                    break;
                case "SEASON":
                    Debug.Log("Successful COOK match");
                    event_SEASON.Invoke(str_temp_final_input);
                    gobj_commandSequencer.ReadyCommand();
                    break;
                case "GRILL":
                    Debug.Log("Successful GRILL match");
                    event_GRILL.Invoke(str_temp_final_input);
                    gobj_commandSequencer.ReadyCommand();
                    break;
                case "GRAB":
                    Debug.Log("Successful GRAB match");
                    event_GRAB.Invoke(str_temp_final_input);
                    gobj_commandSequencer.PushCommand(string.Format("SERVE {0}", str_temp_final_input.Split().Last()));
                    gobj_commandSequencer.ReadyCommand();
                    break;
                case "SERVE":
                    Debug.Log("Successful SERVE match");
                    event_SERVE.Invoke(str_temp_final_input);
                    Debug.Log(str_temp_final_input);
                    break;
                default:
                    Debug.Log("Successful BONUS match");
                    event_BONUS.Invoke(str_temp_final_input);
                    gobj_commandSequencer.ReadyCommand();
                    break;
            }
        }
        else
        {
            InvalidMatch(str_temp_final_input);
        }

    }

    private void InvalidMatch(string str_input)
    {
        text_CommandTextBox.text = ChangeTextColor(str_input, "red");
        gobj_InputText.PauseInput();
        StartCoroutine(IncorrectInput());
    }

    private IEnumerator IncorrectInput()
    {
        while (true)
        {
            yield return wait_IncorrectInputPause;
                SetNewCommand(str_CommandToMatch);
                gobj_InputText.ResumeInput();
            break;
        }
    }



    private string GenGoodCharacter(char char_next_char)
    {
        return "<color=green>" + char_next_char + "</color>";
    }

    private string GenBadCharacter(char char_next_char)
    {
        if (char_next_char != ' ')
            return "<color=red>" + char_next_char + "</color>";
        else
            return "<color=red>_</color>";
    }

    private string ChangeTextColor(string str_old_str, string str_color)
    {
        return "<color=" + str_color + ">" + str_old_str + "</color>";
    }

}
