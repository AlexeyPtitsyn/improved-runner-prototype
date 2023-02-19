using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Awake()
    {
        
    }

    public void OnClickStart()
    {
        Debug.Log("Starting a new game...");
        SceneManager.LoadScene(1);
    }

    public void OnClickExit()
    {
        Debug.Log("Exit");
    }
}
