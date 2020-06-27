using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class script_CommandMatchingScript : MonoBehaviour
{
    [SerializeField] private Text text_CommandTextBox = null;
    [SerializeField] private script_InputTest customType_InputText = null;

    private string str_CommandToMatch = "THIS IS A TEST FOR COLOR CHANGING";



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetNewCommand(string new_command)
    {
        str_CommandToMatch = new_command;
        //text_CommandTextBox.text = str_CommandToMatch;
    }

    public void ChangeTextColors(string current_input)
    {
        text_CommandTextBox.text = "";
        int int_command_str_index = 0;
        for (int i = 0; i < current_input.Length; ++i)
        {
            if ((int_command_str_index >= str_CommandToMatch.Length) || (current_input[i] != str_CommandToMatch[int_command_str_index]))
            {
                text_CommandTextBox.text += GenBadCharacter(current_input[i]);
            }
            else
            {
                text_CommandTextBox.text += GenGoodCharacter(current_input[i]);
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

    private string GenGoodCharacter(char c)
    {
        return "<color=green>" + c + "</color>";
    }

    private string GenBadCharacter(char c)
    {
        return "<color=red>" + c + "</color>";
    }
}
