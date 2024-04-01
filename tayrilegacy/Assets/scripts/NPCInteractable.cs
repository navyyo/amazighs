using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class NPCInteractable : MonoBehaviour
{
    // Start is called before the first frame update
  
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void Interact()
    {
    }
   
}
