using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.Events;


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

    [Header("Command Listeners")]
    public CommandEvent event_COOK = new CommandEvent();
    public CommandEvent event_MOVE = new CommandEvent();
    public CommandEvent event_BONUS = new CommandEvent();

    private string str_CommandToMatch;

    [Header("Delay after Incorrect Input")]
    [SerializeField] private float float_IncorrectInputDelay;
    private static WaitForSeconds wait_IncorrectInputPause;

    // Start is called before the first frame update
    void Start()
    {
        SetNewCommand("MOVE COMMAND NUMBER ONE");
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
    }

    public void ChangeTextColors(string str_current_input)
    {
        text_CommandTextBox.text = "";
        int int_command_str_index = 0;
        for (int i = 0; i < str_current_input.Length; ++i)
        {
            if ((int_command_str_index >= str_CommandToMatch.Length) || (str_current_input[i] != str_CommandToMatch[int_command_str_index]))
            {
                text_CommandTextBox.text += GenBadCharacter(str_current_input[i]);
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
                case "MOVE":
                    Debug.Log("Successful MOVE match");
                    event_COOK.Invoke(str_temp_final_input);
                    break;
                case "COOK":
                    Debug.Log("Successful COOK match");
                    event_COOK.Invoke(str_temp_final_input);
                    break;
                default:
                    Debug.Log("Successful BONUS match");
                    event_BONUS.Invoke(str_temp_final_input);
                    break;
            }
            SetNewCommand(gobj_commandSequencer.GetNextCommand());
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
        return "<color=red>" + char_next_char + "</color>";
    }

    private string ChangeTextColor(string str_old_str, string str_color)
    {
        return "<color=" + str_color + ">" + str_old_str + "</color>";
    }

}
