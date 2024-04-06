using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    private Animator animator;
    public Dialogue dialogue; // Reference to the Dialogue script

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Interact()
    {
        if (dialogue != null)
        {
            dialogue.StartDialogue(); // Call StartDialogue method of the Dialogue script
        }
        else
        {
            Debug.LogWarning("Dialogue script reference not assigned!");
        }
    }
}

