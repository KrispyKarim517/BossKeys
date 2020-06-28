using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_CommandSequencer : MonoBehaviour
{
    private char char_CommandCounter = 'A';

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetNextCommand()
    {
        return string.Format("COMMAND {0}", char_CommandCounter++); ;
    }
}
