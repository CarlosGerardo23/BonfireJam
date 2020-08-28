// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""UIGameplay"",
            ""id"": ""5f3c1bcc-25ea-4cc8-859d-4a7b49479e42"",
            ""actions"": [
                {
                    ""name"": ""TestStart"",
                    ""type"": ""Button"",
                    ""id"": ""2911728b-d854-4394-88c0-55c1c3e54fc0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveSelection"",
                    ""type"": ""Value"",
                    ""id"": ""081cf5b3-44f4-4c1f-9890-b5a6f64b6e7b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""362bb915-3198-44eb-8246-7a7badd5cba5"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TestStart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e26c2a0f-e274-407c-9b68-655143724959"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveSelection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // UIGameplay
        m_UIGameplay = asset.FindActionMap("UIGameplay", throwIfNotFound: true);
        m_UIGameplay_TestStart = m_UIGameplay.FindAction("TestStart", throwIfNotFound: true);
        m_UIGameplay_MoveSelection = m_UIGameplay.FindAction("MoveSelection", throwIfNotFound: true);
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

    // UIGameplay
    private readonly InputActionMap m_UIGameplay;
    private IUIGameplayActions m_UIGameplayActionsCallbackInterface;
    private readonly InputAction m_UIGameplay_TestStart;
    private readonly InputAction m_UIGameplay_MoveSelection;
    public struct UIGameplayActions
    {
        private @PlayerControls m_Wrapper;
        public UIGameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @TestStart => m_Wrapper.m_UIGameplay_TestStart;
        public InputAction @MoveSelection => m_Wrapper.m_UIGameplay_MoveSelection;
        public InputActionMap Get() { return m_Wrapper.m_UIGameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIGameplayActions set) { return set.Get(); }
        public void SetCallbacks(IUIGameplayActions instance)
        {
            if (m_Wrapper.m_UIGameplayActionsCallbackInterface != null)
            {
                @TestStart.started -= m_Wrapper.m_UIGameplayActionsCallbackInterface.OnTestStart;
                @TestStart.performed -= m_Wrapper.m_UIGameplayActionsCallbackInterface.OnTestStart;
                @TestStart.canceled -= m_Wrapper.m_UIGameplayActionsCallbackInterface.OnTestStart;
                @MoveSelection.started -= m_Wrapper.m_UIGameplayActionsCallbackInterface.OnMoveSelection;
                @MoveSelection.performed -= m_Wrapper.m_UIGameplayActionsCallbackInterface.OnMoveSelection;
                @MoveSelection.canceled -= m_Wrapper.m_UIGameplayActionsCallbackInterface.OnMoveSelection;
            }
            m_Wrapper.m_UIGameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @TestStart.started += instance.OnTestStart;
                @TestStart.performed += instance.OnTestStart;
                @TestStart.canceled += instance.OnTestStart;
                @MoveSelection.started += instance.OnMoveSelection;
                @MoveSelection.performed += instance.OnMoveSelection;
                @MoveSelection.canceled += instance.OnMoveSelection;
            }
        }
    }
    public UIGameplayActions @UIGameplay => new UIGameplayActions(this);
    public interface IUIGameplayActions
    {
        void OnTestStart(InputAction.CallbackContext context);
        void OnMoveSelection(InputAction.CallbackContext context);
    }
}
