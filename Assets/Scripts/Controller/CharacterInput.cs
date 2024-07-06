//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/Controller/CharacterInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @CharacterInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @CharacterInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CharacterInput"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""0b3ef114-8049-4a8b-88f6-4286b60d6245"",
            ""actions"": [
                {
                    ""name"": ""movement"",
                    ""type"": ""Value"",
                    ""id"": ""27264d66-e12d-4d97-9601-08c9e3e51e81"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""tool1"",
                    ""type"": ""Button"",
                    ""id"": ""af9ffe5f-27d9-4c57-8a87-91b17ac9a923"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""tool2"",
                    ""type"": ""Button"",
                    ""id"": ""561e8360-4604-4dc1-94e4-4bd891982f3b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""tool3"",
                    ""type"": ""Button"",
                    ""id"": ""7edda051-7771-4230-b447-89360b61c884"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""tool4"",
                    ""type"": ""Button"",
                    ""id"": ""d08d57af-fac3-4ec9-9a79-29a4d21eacb3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""boost"",
                    ""type"": ""Button"",
                    ""id"": ""3a05e80f-ea80-43be-bc81-dea8903b8c98"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""gps"",
                    ""type"": ""Button"",
                    ""id"": ""51970fbf-8a1d-44d7-9535-d989bbbd7c63"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""2041150a-2426-4dd9-ac9b-6b1186ab5fb0"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d34cb69f-854f-453b-a5da-b1fc39fff616"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""39c2b792-110d-47c6-9289-1cdf98465e0d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f6845e2e-b8d0-413a-afa5-cabf4279f1ba"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""03aaba80-0ae9-45ef-ad1c-47e32c23a00c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""d956e244-2bb3-494a-846d-28cf5fc1ce7d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ff5f1eb1-9c06-44da-a452-91a29d48dff1"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""50013d92-09ac-4a8e-8818-b7ec2131e34e"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""eb4a16cb-743c-47a4-9ac9-453be166aab2"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7f57314e-74a6-467c-804e-b231d302e7c3"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""aa24dcc0-943d-4dad-9561-04d906758243"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""tool1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""52ca0f6c-72fc-481e-9b18-419971e91915"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""tool1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""af80faa0-fa5f-44ac-a60b-f71ee9b45fce"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""tool2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dc7f9212-4c36-458b-9086-44c90afd54a5"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""tool2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3a75833a-5d11-470a-8b0d-e114b4f4f6c7"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""tool3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ad9a0842-6177-42bf-93d3-398259034484"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""tool3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c73402c6-767a-4b52-9181-132529910445"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""tool4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""612bcf99-ebcf-402a-b3ca-877b8587027c"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""tool4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b0e8c40f-561e-480e-b2f5-45fbb2d23833"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""boost"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eef38c50-180f-4a54-8e2f-cd0a0e23d5b4"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""boost"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""941899ed-2a61-43ad-8bec-11993fb14d68"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""gps"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""72ad568e-175b-4a98-9d44-27ee7872e7c5"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""gps"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_movement = m_Player.FindAction("movement", throwIfNotFound: true);
        m_Player_tool1 = m_Player.FindAction("tool1", throwIfNotFound: true);
        m_Player_tool2 = m_Player.FindAction("tool2", throwIfNotFound: true);
        m_Player_tool3 = m_Player.FindAction("tool3", throwIfNotFound: true);
        m_Player_tool4 = m_Player.FindAction("tool4", throwIfNotFound: true);
        m_Player_boost = m_Player.FindAction("boost", throwIfNotFound: true);
        m_Player_gps = m_Player.FindAction("gps", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_movement;
    private readonly InputAction m_Player_tool1;
    private readonly InputAction m_Player_tool2;
    private readonly InputAction m_Player_tool3;
    private readonly InputAction m_Player_tool4;
    private readonly InputAction m_Player_boost;
    private readonly InputAction m_Player_gps;
    public struct PlayerActions
    {
        private @CharacterInput m_Wrapper;
        public PlayerActions(@CharacterInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @movement => m_Wrapper.m_Player_movement;
        public InputAction @tool1 => m_Wrapper.m_Player_tool1;
        public InputAction @tool2 => m_Wrapper.m_Player_tool2;
        public InputAction @tool3 => m_Wrapper.m_Player_tool3;
        public InputAction @tool4 => m_Wrapper.m_Player_tool4;
        public InputAction @boost => m_Wrapper.m_Player_boost;
        public InputAction @gps => m_Wrapper.m_Player_gps;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @movement.started += instance.OnMovement;
            @movement.performed += instance.OnMovement;
            @movement.canceled += instance.OnMovement;
            @tool1.started += instance.OnTool1;
            @tool1.performed += instance.OnTool1;
            @tool1.canceled += instance.OnTool1;
            @tool2.started += instance.OnTool2;
            @tool2.performed += instance.OnTool2;
            @tool2.canceled += instance.OnTool2;
            @tool3.started += instance.OnTool3;
            @tool3.performed += instance.OnTool3;
            @tool3.canceled += instance.OnTool3;
            @tool4.started += instance.OnTool4;
            @tool4.performed += instance.OnTool4;
            @tool4.canceled += instance.OnTool4;
            @boost.started += instance.OnBoost;
            @boost.performed += instance.OnBoost;
            @boost.canceled += instance.OnBoost;
            @gps.started += instance.OnGps;
            @gps.performed += instance.OnGps;
            @gps.canceled += instance.OnGps;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @movement.started -= instance.OnMovement;
            @movement.performed -= instance.OnMovement;
            @movement.canceled -= instance.OnMovement;
            @tool1.started -= instance.OnTool1;
            @tool1.performed -= instance.OnTool1;
            @tool1.canceled -= instance.OnTool1;
            @tool2.started -= instance.OnTool2;
            @tool2.performed -= instance.OnTool2;
            @tool2.canceled -= instance.OnTool2;
            @tool3.started -= instance.OnTool3;
            @tool3.performed -= instance.OnTool3;
            @tool3.canceled -= instance.OnTool3;
            @tool4.started -= instance.OnTool4;
            @tool4.performed -= instance.OnTool4;
            @tool4.canceled -= instance.OnTool4;
            @boost.started -= instance.OnBoost;
            @boost.performed -= instance.OnBoost;
            @boost.canceled -= instance.OnBoost;
            @gps.started -= instance.OnGps;
            @gps.performed -= instance.OnGps;
            @gps.canceled -= instance.OnGps;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnTool1(InputAction.CallbackContext context);
        void OnTool2(InputAction.CallbackContext context);
        void OnTool3(InputAction.CallbackContext context);
        void OnTool4(InputAction.CallbackContext context);
        void OnBoost(InputAction.CallbackContext context);
        void OnGps(InputAction.CallbackContext context);
    }
}
