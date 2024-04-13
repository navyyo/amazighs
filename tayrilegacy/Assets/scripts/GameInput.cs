using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    // Start is called before the first frame update
    public event EventHandler OnInteractAction;
    private PlayerInputActions playerInputActions;
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Pmovement.Enable();
        playerInputActions.Pmovement.Interact.performed += Interact_performed;



    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
       OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
