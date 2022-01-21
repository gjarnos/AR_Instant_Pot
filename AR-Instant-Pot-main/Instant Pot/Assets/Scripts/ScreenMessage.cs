using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScreenMessage : Singleton<ScreenMessage>
{
    [SerializeField]
    TextMeshProUGUI textForTransform, textForTransform2;

    private void _logForModelTransform(string msg)
    {
        if (msg[0] != '\n')
        {
            if (msg.Length > 25)
            {
                msg = "";
            }
            msg = '\n' + msg;
        }

        textForTransform.text = msg;
        Debug.Log(msg);
    }

    private void _logForModelTransform2(string msg)
    {
        if (msg[0] != '\n')
        {
            msg = '\n' + msg;
        }

        textForTransform2.text = msg;
        Debug.Log(msg);
    }

    public static void LogForModelTransform(string msg)
    {
        Instance._logForModelTransform(msg);
    }

    public static void LogForModelTransform2(string msg)
    {
        Instance._logForModelTransform2(msg);
    }
}
