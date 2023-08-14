using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public static event Action OnPause;
    [SerializeField] private Scenes pauseScene;

    private PlayerInput playerInput;
    private InputAction pauseAction;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        pauseAction = playerInput.actions["Pause"];
    }
    private void OnEnable()
    {
        pauseAction.performed += PauseAction;
    }
    private void OnDisable()
    {
        pauseAction.performed -= PauseAction;
    }
    private void PauseAction(InputAction.CallbackContext ctx)
    {
        OnPause?.Invoke();
    }
}
