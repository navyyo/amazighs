using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pmovement : MonoBehaviour
{
    Player playerC;
    public Vector2 mvtInput;
    private void OnEnable()
    {
        if (playerC == null)
        {
            playerC = new Player();
            playerC.Pmovement.movement.performed += i => mvtInput = i.ReadValue<Vector2>();
            playerC.Enable();
        }
    }
    private void OnDisable()
    {
        playerC.Disable();
    }
}
