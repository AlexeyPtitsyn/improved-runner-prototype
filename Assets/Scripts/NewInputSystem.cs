/**
 * New input system.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class NewInputSystem : Player
{
    public InputActions Controls;

    protected void Awake()
    {
        Controls = new InputActions();
    }

    protected override void Start()
    {
        base.Start();

        StartCoroutine(ControlMove());
    }

    IEnumerator ControlMove()
    {
        while(true)
        {
            var moveAxis = Controls.ActionMap.Move.ReadValue<float>();
            int horRounded = (int)Mathf.Round(moveAxis);
            _hisShip.Roll(horRounded);

            if (horRounded != 0)
            {
                Move(horRounded);
            }

            yield return new WaitForFixedUpdate();
        }
    }

    private void OnJump(CallbackContext context)
    {
        if (!_inAir)
        {
            _inAir = true;
            Jump();
        }
    }

    private void OnQuit(CallbackContext context)
    {
        Logger.Log("Exiting the game (escape pressed).");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif !UNITY_EDITOR && UNITY_STANDALONE
        Application.Quit();
#endif
    }

    private void OnEnable()
    {
        Controls.ActionMap.Enable();
        Controls.ActionMap.Jump.performed += OnJump;
        Controls.ActionMap.Quit.performed += OnQuit;
    }

    private void OnDisable()
    {
        Controls.ActionMap.Jump.performed -= OnJump;
        Controls.ActionMap.Quit.performed -= OnQuit;
        Controls.ActionMap.Disable();
    }

}
