using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_InputTest : MonoBehaviour
{

    string str_InputStr = "";

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
                Debug.Log(str_InputStr);
            }
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if (str_InputStr.Length != 0)
            {
                str_InputStr = str_InputStr.Remove(str_InputStr.Length - 1);
                Debug.Log(str_InputStr);
            }
        }
    }
}
