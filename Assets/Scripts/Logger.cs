using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Logger
{
    public static void Log(string str)
    {
#if UNITY_EDITOR
#elif !UNITY_EDITOR && UNITY_STANDALONE
#endif
        Debug.Log(str);
    }
}
