using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class script_CommandMatchingScript : MonoBehaviour
{
    [SerializeField] private Text text_CommandTextBox = null;
    [SerializeField] private script_InputTest customType_InputText = null;

    private string str_CommandToMatch;



    // Start is called before the first frame update
    void Start()
    {
        SetNewCommand("MOVE COMMAND NUMBER ONE");
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
        ChangeTextColors(customType_InputText.GetCurrentInput());
    }

    public void ReturnKeyPressLister()
    {
        string str_temp_final_input = customType_InputText.GetFinalInput();
        
        if (str_temp_final_input == str_CommandToMatch)
        {
            switch (str_temp_final_input.Split()[0])
            {
                case "MOVE":
                    Debug.Log("Successful MOVE match");
                    break;
                case "COOK":
                    Debug.Log("Successful COOK match");
                    break;
                default:
                    Time.timeScale = 0;
                    Debug.Log("BAD MATCH!!! SHOULD NEVER PRINT!!!!");
                    break;
            }
            SetNewCommand("COOK COMMAND NUMBER TWO");
        }
        else
        {
            InvalidMatch();
        }

    }

    private void InvalidMatch()
    {

    }

    private string GenGoodCharacter(char char_next_char)
    {
        return "<color=green>" + char_next_char + "</color>";
    }

    private string GenBadCharacter(char char_next_char)
    {
        return "<color=red>" + char_next_char + "</color>";
    }
}
