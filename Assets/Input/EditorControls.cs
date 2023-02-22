// GENERATED AUTOMATICALLY FROM 'Assets/Input/EditorControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @EditorControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @EditorControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""EditorControls"",
    ""maps"": [
        {
            ""name"": ""ActionMap"",
            ""id"": ""02eb46b2-493c-48ca-9444-62c569987388"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""de1fdc09-6fc8-49d5-b716-f5c784019119"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""50de94c9-e811-4204-a58b-c4c1f7d5d399"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""Quit"",
                    ""type"": ""Button"",
                    ""id"": ""774d7439-6cf9-4996-ae62-58144517e865"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5e69efd8-596a-4ca0-8a93-0f3ac59ad838"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""09a4e2e8-9509-4c84-afec-7edefbd1f470"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""b2bfd565-a3d9-42a2-85f1-d331bb511763"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""2de789ec-5cf4-46c7-ac92-2ced7bcf1113"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f2207c31-633f-4820-9ea1-023449e3e721"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // ActionMap
        m_ActionMap = asset.FindActionMap("ActionMap", throwIfNotFound: true);
        m_ActionMap_Jump = m_ActionMap.FindAction("Jump", throwIfNotFound: true);
        m_ActionMap_Move = m_ActionMap.FindAction("Move", throwIfNotFound: true);
        m_ActionMap_Quit = m_ActionMap.FindAction("Quit", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // ActionMap
    private readonly InputActionMap m_ActionMap;
    private IActionMapActions m_ActionMapActionsCallbackInterface;
    private readonly InputAction m_ActionMap_Jump;
    private readonly InputAction m_ActionMap_Move;
    private readonly InputAction m_ActionMap_Quit;
    public struct ActionMapActions
    {
        private @EditorControls m_Wrapper;
        public ActionMapActions(@EditorControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_ActionMap_Jump;
        public InputAction @Move => m_Wrapper.m_ActionMap_Move;
        public InputAction @Quit => m_Wrapper.m_ActionMap_Quit;
        public InputActionMap Get() { return m_Wrapper.m_ActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ActionMapActions set) { return set.Get(); }
        public void SetCallbacks(IActionMapActions instance)
        {
            if (m_Wrapper.m_ActionMapActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnJump;
                @Move.started -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnMove;
                @Quit.started -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnQuit;
                @Quit.performed -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnQuit;
                @Quit.canceled -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnQuit;
            }
            m_Wrapper.m_ActionMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Quit.started += instance.OnQuit;
                @Quit.performed += instance.OnQuit;
                @Quit.canceled += instance.OnQuit;
            }
        }
    }
    public ActionMapActions @ActionMap => new ActionMapActions(this);
    public interface IActionMapActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnQuit(InputAction.CallbackContext context);
    }
}
