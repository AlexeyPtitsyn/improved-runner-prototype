// Improved logger.
// Copyright Alexey Ptitsyn <alexey.ptitsyn@gmail.com>, 2023
using System;
using System.IO;
using UnityEngine;

public static class Logger
{
    public static void Log(string str)
    {
#if UNITY_EDITOR
        Debug.Log(str);
#elif !UNITY_EDITOR && UNITY_STANDALONE
        DateTime dt = DateTime.Now;
        string path = Application.persistentDataPath + "/log.txt";
        string outStr = $"{dt.ToString("[yyyy-MM-dd HH:mm:ss]")} {str}";

        using (StreamWriter sw = File.AppendText(path))
        {
            sw.WriteLine(outStr);
        }
#endif

    }
}
