// New input system.
// Copyright Alexey Ptitsyn <alexey.ptitsyn@gmail.com>, 2023
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class NewInputSystem : Player
{
    public InputActions ProductionControls;
    public EditorControls DevelopmentControls;

    protected void Awake()
    {
        DevelopmentControls = new EditorControls();
        ProductionControls = new InputActions();
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
#if UNITY_EDITOR
            var moveAxis = DevelopmentControls.ActionMap.Move.ReadValue<float>();
#elif !UNITY_EDITOR && UNITY_STANDALONE
            var moveAxis = ProductionControls.ActionMap.Move.ReadValue<float>();
#endif

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
        Logger.Log("Jump pressed.");
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
#if UNITY_EDITOR
        DevelopmentControls.ActionMap.Enable();
        DevelopmentControls.ActionMap.Jump.performed += OnJump;
        DevelopmentControls.ActionMap.Quit.performed += OnQuit;
#elif !UNITY_EDITOR && UNITY_STANDALONE
        ProductionControls.ActionMap.Enable();
        ProductionControls.ActionMap.Jump.performed += OnJump;
        ProductionControls.ActionMap.Quit.performed += OnQuit;
#endif

    }

    private void OnDisable()
    {
#if UNITY_EDITOR
        DevelopmentControls.ActionMap.Jump.performed -= OnJump;
        DevelopmentControls.ActionMap.Quit.performed -= OnQuit;
        DevelopmentControls.ActionMap.Disable();
#elif !UNITY_EDITOR && UNITY_STANDALONE
        ProductionControls.ActionMap.Jump.performed -= OnJump;
        ProductionControls.ActionMap.Quit.performed -= OnQuit;
        ProductionControls.ActionMap.Disable();
#endif
    }

}
