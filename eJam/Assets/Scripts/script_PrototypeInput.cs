using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class script_PrototypeInput : MonoBehaviour
{
    public GameObject gobj_Target;
    public float float_Speed;
    public InputField ui_UserInput;

    // Start is called before the first frame update
    void Start()
    {
        ui_UserInput.onEndEdit.AddListener(delegate { InputParser(ui_UserInput); });
    }

    void InputParser(InputField userInput)
    {
        string[] str_InputWords = ui_UserInput.text.Split(' ');
        Debug.Log(str_InputWords[0]);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ui_UserInput.text == "move to weapon")
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, gobj_Target.transform.position, float_Speed * Time.fixedDeltaTime);
        }
    }
}
