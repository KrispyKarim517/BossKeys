using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class script_CommandMatchingScript : MonoBehaviour
{
    [SerializeField] private Text text_CommandTextBox = null;

    private string str_CommandToMatch = "";



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
        text_CommandTextBox.text = str_CommandToMatch;
    }

    public bool CheckMatch(string current_input)
    {
        return str_CommandToMatch == current_input;
    }
}
