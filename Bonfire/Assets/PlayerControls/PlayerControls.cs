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
        },
        {
            ""name"": ""PlayerMovement"",
            ""id"": ""bae8e2dd-15ee-4658-ac88-be8c974fa1e7"",
            ""actions"": [
                {
                    ""name"": ""OnMove"",
                    ""type"": ""Value"",
                    ""id"": ""743a6a0d-e401-4648-9c31-aff699265210"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jumping"",
                    ""type"": ""Button"",
                    ""id"": ""27458e86-9735-4b32-91b5-5ec706577636"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7b11773b-54b3-4ff1-a240-6a375f703c5c"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d4f9c9ef-bbf1-4507-a304-38e84c3e0fd4"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jumping"",
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
        // PlayerMovement
        m_PlayerMovement = asset.FindActionMap("PlayerMovement", throwIfNotFound: true);
        m_PlayerMovement_OnMove = m_PlayerMovement.FindAction("OnMove", throwIfNotFound: true);
        m_PlayerMovement_Jumping = m_PlayerMovement.FindAction("Jumping", throwIfNotFound: true);
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

    // PlayerMovement
    private readonly InputActionMap m_PlayerMovement;
    private IPlayerMovementActions m_PlayerMovementActionsCallbackInterface;
    private readonly InputAction m_PlayerMovement_OnMove;
    private readonly InputAction m_PlayerMovement_Jumping;
    public struct PlayerMovementActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerMovementActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @OnMove => m_Wrapper.m_PlayerMovement_OnMove;
        public InputAction @Jumping => m_Wrapper.m_PlayerMovement_Jumping;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMovementActions instance)
        {
            if (m_Wrapper.m_PlayerMovementActionsCallbackInterface != null)
            {
                @OnMove.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnOnMove;
                @OnMove.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnOnMove;
                @OnMove.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnOnMove;
                @Jumping.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnJumping;
                @Jumping.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnJumping;
                @Jumping.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnJumping;
            }
            m_Wrapper.m_PlayerMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @OnMove.started += instance.OnOnMove;
                @OnMove.performed += instance.OnOnMove;
                @OnMove.canceled += instance.OnOnMove;
                @Jumping.started += instance.OnJumping;
                @Jumping.performed += instance.OnJumping;
                @Jumping.canceled += instance.OnJumping;
            }
        }
    }
    public PlayerMovementActions @PlayerMovement => new PlayerMovementActions(this);
    public interface IUIGameplayActions
    {
        void OnTestStart(InputAction.CallbackContext context);
        void OnMoveSelection(InputAction.CallbackContext context);
    }
    public interface IPlayerMovementActions
    {
        void OnOnMove(InputAction.CallbackContext context);
        void OnJumping(InputAction.CallbackContext context);
    }
}
