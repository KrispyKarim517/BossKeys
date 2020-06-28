using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class script_InputText : MonoBehaviour
{
    [Header("Input Text Box")]
    [SerializeField] private Text text_InputTextBox = null;

    [Header("Minimum Time between Backspaces (in seconds)")]
    [SerializeField] private float float_BackspaceCooldown = 0.1f; //Game runs to fast to only use GetKey

    [Header("Key Press Events")]
    public UnityEvent event_ValidKeyPressed = new UnityEvent();
    public UnityEvent event_ReturnKeyPressed = new UnityEvent();

    private string str_InputStr = "";
    private string str_FinalInput = "";
    private float float_TimePassed;
    private bool bool_InputPaused = false;


    Dictionary<KeyCode, char> dict_Alphabet = new Dictionary<KeyCode, char>()
                                        {
                                           { KeyCode.A, 'A' },
                                           { KeyCode.B, 'B' },
                                           { KeyCode.C, 'C' },
                                           { KeyCode.D, 'D' },
                                           { KeyCode.E, 'E' },
                                           { KeyCode.F, 'F' },
                                           { KeyCode.G, 'G' },
                                           { KeyCode.H, 'H' },
                                           { KeyCode.I, 'I' },
                                           { KeyCode.J, 'J' },
                                           { KeyCode.K, 'K' },
                                           { KeyCode.L, 'L' },
                                           { KeyCode.M, 'M' },
                                           { KeyCode.N, 'N' },
                                           { KeyCode.O, 'O' },
                                           { KeyCode.P, 'P' },
                                           { KeyCode.Q, 'Q' },
                                           { KeyCode.R, 'R' },
                                           { KeyCode.S, 'S' },
                                           { KeyCode.T, 'T' },
                                           { KeyCode.U, 'U' },
                                           { KeyCode.V, 'V' },
                                           { KeyCode.W, 'W' },
                                           { KeyCode.X, 'X' },
                                           { KeyCode.Y, 'Y' },
                                           { KeyCode.Z, 'Z' },
                                           { KeyCode.Space, ' ' },
                                        };

    // Start is called before the first frame update
    void Start()
    {
        float_TimePassed = float_BackspaceCooldown + 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!bool_InputPaused)
        {
            foreach (KeyCode key in dict_Alphabet.Keys)
            {
                if (Input.GetKeyDown(key))
                {
                    str_FinalInput = "";
                    str_InputStr += dict_Alphabet[key];
                    text_InputTextBox.text = str_InputStr;
                    event_ValidKeyPressed.Invoke();
                }
            }
            if (Input.GetKey(KeyCode.Backspace))
            {
                if (str_InputStr.Length != 0)
                {
                    if (float_TimePassed > float_BackspaceCooldown)
                    {
                        str_FinalInput = "";
                        str_InputStr = str_InputStr.Remove(str_InputStr.Length - 1);
                        text_InputTextBox.text = str_InputStr;
                        float_TimePassed = 0;
                        event_ValidKeyPressed.Invoke();
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                //Debug.Log(str_InputStr);
                str_FinalInput = str_InputStr;
                event_ReturnKeyPressed.Invoke();
                str_InputStr = "";
                text_InputTextBox.text = str_InputStr;
            }
            float_TimePassed += Time.deltaTime;
        }
    }

    public string GetCurrentInput()
    {
        return str_InputStr;
    }

    public string GetFinalInput()
    {
        return str_FinalInput;
    }

    public void PauseInput()
    {
        bool_InputPaused = true;
    }

    public void ResumeInput()
    {
        bool_InputPaused = false;
    }
}