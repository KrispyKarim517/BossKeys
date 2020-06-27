using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class script_InputTest : MonoBehaviour
{
    [SerializeField] private Text text_InputTextBox = null;
    public static float float_BackspaceCooldown = 0.1f; //Game runs to fast to only use GetKey


    private string str_InputStr = "";
    private float float_TimePassed = float_BackspaceCooldown + 1f;


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

    }

    // Update is called once per frame
    void Update()
    {
        foreach (KeyCode key in dict_Alphabet.Keys)
        {
            if (Input.GetKeyDown(key))
            {
                str_InputStr += dict_Alphabet[key];
                text_InputTextBox.text = str_InputStr;
            }
        }
        if (Input.GetKey(KeyCode.Backspace))
        {
            if (str_InputStr.Length != 0)
            {
                if (float_TimePassed > float_BackspaceCooldown)
                {
                    str_InputStr = str_InputStr.Remove(str_InputStr.Length - 1);
                    text_InputTextBox.text = str_InputStr;
                    float_TimePassed = 0;
                }
            }
        }
        float_TimePassed += Time.deltaTime;
    }
}