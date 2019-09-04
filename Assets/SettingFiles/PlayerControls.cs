// GENERATED AUTOMATICALLY FROM 'Assets/SettingFiles/PlayerControls.inputactions'

using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerControls : IInputActionCollection
{
    private InputActionAsset asset;
    public PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""GamePlay"",
            ""id"": ""7e0b66c6-39ca-4e2d-b997-1668447eeaaa"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""c3ad1838-a0f0-47df-a69b-f10ec5cbb6dc"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""ac78225d-612f-4bb6-bab0-49c8cd5801f5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""8a10e3eb-5f9d-4a5c-8008-7f63b1562985"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Roll"",
                    ""type"": ""Button"",
                    ""id"": ""df2c63b9-415d-4904-9f73-93a87cd1ee5a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Item"",
                    ""type"": ""Button"",
                    ""id"": ""747671ca-c311-468e-ab78-b5c3bcdc8732"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d66c9576-291f-4870-a636-d34116aac8df"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""ab6f03d7-f347-4c64-910e-fe60d97c18d4"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9c30fded-5272-4040-84ed-23fd3d528320"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""084e3788-a048-4df5-a968-bc1fcadad516"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""deba99c9-3c68-4c95-ae8f-42249716955d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9175caf1-a48f-4e5e-9fcd-790661e00279"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""891b3919-3405-431b-b20b-98eb25ef876e"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7838d491-54ac-46ab-bb94-fe33e962b27d"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""83319ea7-c420-4c38-8145-593b99966906"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""630fb9ee-870c-49e1-ad2f-e8416b59768d"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""251b6b1d-d854-405c-ae3a-1b23c72ba9e1"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""20fe906b-10cd-4a66-a7dd-66b8af838c49"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""85c0d649-1c98-4f94-83ab-c4a7b070aaf2"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Item"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""37e616c5-0c57-4ccb-b61c-d3a76d39c70b"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Item"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GamePlay
        m_GamePlay = asset.GetActionMap("GamePlay");
        m_GamePlay_Move = m_GamePlay.GetAction("Move");
        m_GamePlay_Attack = m_GamePlay.GetAction("Attack");
        m_GamePlay_Jump = m_GamePlay.GetAction("Jump");
        m_GamePlay_Roll = m_GamePlay.GetAction("Roll");
        m_GamePlay_Item = m_GamePlay.GetAction("Item");
    }

    ~PlayerControls()
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

    // GamePlay
    private readonly InputActionMap m_GamePlay;
    private IGamePlayActions m_GamePlayActionsCallbackInterface;
    private readonly InputAction m_GamePlay_Move;
    private readonly InputAction m_GamePlay_Attack;
    private readonly InputAction m_GamePlay_Jump;
    private readonly InputAction m_GamePlay_Roll;
    private readonly InputAction m_GamePlay_Item;
    public struct GamePlayActions
    {
        private PlayerControls m_Wrapper;
        public GamePlayActions(PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_GamePlay_Move;
        public InputAction @Attack => m_Wrapper.m_GamePlay_Attack;
        public InputAction @Jump => m_Wrapper.m_GamePlay_Jump;
        public InputAction @Roll => m_Wrapper.m_GamePlay_Roll;
        public InputAction @Item => m_Wrapper.m_GamePlay_Item;
        public InputActionMap Get() { return m_Wrapper.m_GamePlay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamePlayActions set) { return set.Get(); }
        public void SetCallbacks(IGamePlayActions instance)
        {
            if (m_Wrapper.m_GamePlayActionsCallbackInterface != null)
            {
                Move.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMove;
                Move.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMove;
                Move.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMove;
                Attack.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnAttack;
                Attack.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnAttack;
                Attack.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnAttack;
                Jump.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnJump;
                Jump.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnJump;
                Jump.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnJump;
                Roll.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnRoll;
                Roll.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnRoll;
                Roll.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnRoll;
                Item.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnItem;
                Item.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnItem;
                Item.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnItem;
            }
            m_Wrapper.m_GamePlayActionsCallbackInterface = instance;
            if (instance != null)
            {
                Move.started += instance.OnMove;
                Move.performed += instance.OnMove;
                Move.canceled += instance.OnMove;
                Attack.started += instance.OnAttack;
                Attack.performed += instance.OnAttack;
                Attack.canceled += instance.OnAttack;
                Jump.started += instance.OnJump;
                Jump.performed += instance.OnJump;
                Jump.canceled += instance.OnJump;
                Roll.started += instance.OnRoll;
                Roll.performed += instance.OnRoll;
                Roll.canceled += instance.OnRoll;
                Item.started += instance.OnItem;
                Item.performed += instance.OnItem;
                Item.canceled += instance.OnItem;
            }
        }
    }
    public GamePlayActions @GamePlay => new GamePlayActions(this);
    public interface IGamePlayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnRoll(InputAction.CallbackContext context);
        void OnItem(InputAction.CallbackContext context);
    }
}
