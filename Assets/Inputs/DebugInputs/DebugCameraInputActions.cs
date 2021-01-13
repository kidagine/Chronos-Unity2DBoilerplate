// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/DebugInputs/DebugCameraInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @DebugCameraInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @DebugCameraInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""DebugCameraInputActions"",
    ""maps"": [
        {
            ""name"": ""DebugCameraControls"",
            ""id"": ""60ae2455-df20-415a-86f7-84f1433ea869"",
            ""actions"": [
                {
                    ""name"": ""DebugCameraMovement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""88c322fc-e59d-404c-92b4-97e9774395ad"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""ScaleVector2(x=0.05,y=0.05)"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DebugCameraSpeed"",
                    ""type"": ""Button"",
                    ""id"": ""a8b02d04-b435-4bac-acfe-c2de485dbd65"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DebugCameraZoom"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6b0f41b3-92db-4aba-9397-63169f961904"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DebugCameraClose"",
                    ""type"": ""Button"",
                    ""id"": ""e49adc3d-48a2-4360-883c-698dc199a76f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""87841708-0937-4880-a3b7-905a372eb935"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""DebugCameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""2dc31cbc-e59c-45b1-a2b9-c1d6e207689f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DebugCameraMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""608ae8f2-9ab1-4553-a546-882d4b01e7a2"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""DebugCameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""91a395d3-1f53-4241-80d3-07964f45a1c2"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""DebugCameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d4937415-44b3-407c-8cb5-396e64fe6145"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""DebugCameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f2526661-ebbe-4c98-892b-aebd61d612f4"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""DebugCameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""686a3818-4d16-419e-95b0-274b67eb4bc1"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DebugCameraMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c7857523-6c9c-4f88-b818-0e85cc75c62f"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""DebugCameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""121e2366-772e-4876-a8b4-34f6a7b3c481"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""DebugCameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""714f8565-8dde-4a63-9d2f-5ce5afc64efe"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""DebugCameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""41e6e05d-2f37-4606-978e-310604bffab7"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""DebugCameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""7d2493a7-d103-4c15-8398-78e21946a3b1"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""DebugCameraSpeed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3ed9acc6-dcf3-45a3-894f-6635c8cbfb8b"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""DebugCameraSpeed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Triggers"",
                    ""id"": ""9f8fd78a-1ad0-43e8-97f5-57bb1a248038"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DebugCameraZoom"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a1a639f7-0e2d-4e6d-9193-d65bae8e3338"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""DebugCameraZoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9a716c56-ac75-41be-983c-7a10a744678c"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""DebugCameraZoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""09c6c1a3-a459-423c-8bcf-1caa12d4ed91"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""DebugCameraZoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""83cdb381-5d10-4512-97bb-10cb586eba60"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""DebugCameraClose"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9f114071-93d2-49d1-88e7-a8d93a7723b4"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DebugCameraClose"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard&Mouse"",
            ""bindingGroup"": ""Keyboard&Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // DebugCameraControls
        m_DebugCameraControls = asset.FindActionMap("DebugCameraControls", throwIfNotFound: true);
        m_DebugCameraControls_DebugCameraMovement = m_DebugCameraControls.FindAction("DebugCameraMovement", throwIfNotFound: true);
        m_DebugCameraControls_DebugCameraSpeed = m_DebugCameraControls.FindAction("DebugCameraSpeed", throwIfNotFound: true);
        m_DebugCameraControls_DebugCameraZoom = m_DebugCameraControls.FindAction("DebugCameraZoom", throwIfNotFound: true);
        m_DebugCameraControls_DebugCameraClose = m_DebugCameraControls.FindAction("DebugCameraClose", throwIfNotFound: true);
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

    // DebugCameraControls
    private readonly InputActionMap m_DebugCameraControls;
    private IDebugCameraControlsActions m_DebugCameraControlsActionsCallbackInterface;
    private readonly InputAction m_DebugCameraControls_DebugCameraMovement;
    private readonly InputAction m_DebugCameraControls_DebugCameraSpeed;
    private readonly InputAction m_DebugCameraControls_DebugCameraZoom;
    private readonly InputAction m_DebugCameraControls_DebugCameraClose;
    public struct DebugCameraControlsActions
    {
        private @DebugCameraInputActions m_Wrapper;
        public DebugCameraControlsActions(@DebugCameraInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @DebugCameraMovement => m_Wrapper.m_DebugCameraControls_DebugCameraMovement;
        public InputAction @DebugCameraSpeed => m_Wrapper.m_DebugCameraControls_DebugCameraSpeed;
        public InputAction @DebugCameraZoom => m_Wrapper.m_DebugCameraControls_DebugCameraZoom;
        public InputAction @DebugCameraClose => m_Wrapper.m_DebugCameraControls_DebugCameraClose;
        public InputActionMap Get() { return m_Wrapper.m_DebugCameraControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DebugCameraControlsActions set) { return set.Get(); }
        public void SetCallbacks(IDebugCameraControlsActions instance)
        {
            if (m_Wrapper.m_DebugCameraControlsActionsCallbackInterface != null)
            {
                @DebugCameraMovement.started -= m_Wrapper.m_DebugCameraControlsActionsCallbackInterface.OnDebugCameraMovement;
                @DebugCameraMovement.performed -= m_Wrapper.m_DebugCameraControlsActionsCallbackInterface.OnDebugCameraMovement;
                @DebugCameraMovement.canceled -= m_Wrapper.m_DebugCameraControlsActionsCallbackInterface.OnDebugCameraMovement;
                @DebugCameraSpeed.started -= m_Wrapper.m_DebugCameraControlsActionsCallbackInterface.OnDebugCameraSpeed;
                @DebugCameraSpeed.performed -= m_Wrapper.m_DebugCameraControlsActionsCallbackInterface.OnDebugCameraSpeed;
                @DebugCameraSpeed.canceled -= m_Wrapper.m_DebugCameraControlsActionsCallbackInterface.OnDebugCameraSpeed;
                @DebugCameraZoom.started -= m_Wrapper.m_DebugCameraControlsActionsCallbackInterface.OnDebugCameraZoom;
                @DebugCameraZoom.performed -= m_Wrapper.m_DebugCameraControlsActionsCallbackInterface.OnDebugCameraZoom;
                @DebugCameraZoom.canceled -= m_Wrapper.m_DebugCameraControlsActionsCallbackInterface.OnDebugCameraZoom;
                @DebugCameraClose.started -= m_Wrapper.m_DebugCameraControlsActionsCallbackInterface.OnDebugCameraClose;
                @DebugCameraClose.performed -= m_Wrapper.m_DebugCameraControlsActionsCallbackInterface.OnDebugCameraClose;
                @DebugCameraClose.canceled -= m_Wrapper.m_DebugCameraControlsActionsCallbackInterface.OnDebugCameraClose;
            }
            m_Wrapper.m_DebugCameraControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @DebugCameraMovement.started += instance.OnDebugCameraMovement;
                @DebugCameraMovement.performed += instance.OnDebugCameraMovement;
                @DebugCameraMovement.canceled += instance.OnDebugCameraMovement;
                @DebugCameraSpeed.started += instance.OnDebugCameraSpeed;
                @DebugCameraSpeed.performed += instance.OnDebugCameraSpeed;
                @DebugCameraSpeed.canceled += instance.OnDebugCameraSpeed;
                @DebugCameraZoom.started += instance.OnDebugCameraZoom;
                @DebugCameraZoom.performed += instance.OnDebugCameraZoom;
                @DebugCameraZoom.canceled += instance.OnDebugCameraZoom;
                @DebugCameraClose.started += instance.OnDebugCameraClose;
                @DebugCameraClose.performed += instance.OnDebugCameraClose;
                @DebugCameraClose.canceled += instance.OnDebugCameraClose;
            }
        }
    }
    public DebugCameraControlsActions @DebugCameraControls => new DebugCameraControlsActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    public interface IDebugCameraControlsActions
    {
        void OnDebugCameraMovement(InputAction.CallbackContext context);
        void OnDebugCameraSpeed(InputAction.CallbackContext context);
        void OnDebugCameraZoom(InputAction.CallbackContext context);
        void OnDebugCameraClose(InputAction.CallbackContext context);
    }
}