using UnityEngine;

public static class Common
{
    public static void ValidateObject<T>(Object obj, string name, bool isExit = false)
    {
        if (obj == null)
        {
            Debug.Log($"Required object {name} is null!");
            return;
        }

        if (!(obj is T))
        {
            Debug.Log($"Required object {name} has incorrect type!");
        }

        if (isExit)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#elif !UNITY_EDITOR && UNITY_STANDALONE
        Application.Quit();
#endif
        }
    }
}
