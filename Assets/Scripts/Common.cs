// Shared functions.
// Copyright Alexey Ptitsyn <alexey.ptitsyn@gmail.com>, 2023
using UnityEngine;

public static class Common
{
    private static void EmergencyExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif !UNITY_EDITOR && UNITY_STANDALONE
        Application.Quit();
#endif
    }

    public static void ValidateObject<T>(Object obj, string name, bool isExit = false)
    {
        if (obj == null)
        {
            Debug.Log($"Required object {name} is null!");
            if (isExit) EmergencyExit();
            return;
        }

        if (!(obj is T))
        {
            Debug.Log($"Required object {name} has incorrect type!");
            if (isExit) EmergencyExit();
            return;
        }
    }
}
