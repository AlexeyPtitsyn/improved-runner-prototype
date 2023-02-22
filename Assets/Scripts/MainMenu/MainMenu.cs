using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnClickStart()
    {
        Logger.Log("Starting a new game...");
        SceneManager.LoadScene(1);
    }

    public void OnClickExit()
    {
        Logger.Log("Exiting the game...");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif !UNITY_EDITOR && UNITY_STANDALONE
        Application.Quit();
#endif
    }
}
