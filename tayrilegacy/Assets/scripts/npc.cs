using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc : MonoBehaviour
{
    public float interactRange = 2f; // Set the interact range in the Inspector
    public bool isTalking = false;
    private Animator Peasantgirl;
    private GameObject player;

    void Start()
    {
        Peasantgirl = GetComponent<Animator>();
        if (Peasantgirl == null)
        {
            Debug.LogError("Animator component not found on the NPC GameObject!");
        }
        else
        {
            Debug.Log("Animator component found and assigned successfully!");
        }
        player = GameObject.FindGameObjectWithTag("Player");

        // Debug log for interact range
        Debug.Log("Interact Range: " + interactRange);
    }

    void Update()
    {
        // Check if the player is within the interact range
        if (player != null)
        {
            // Debug log for player existence
            Debug.Log("Player found!");

            // Calculate distance between NPC and player
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            Debug.Log("Distance to player: " + distanceToPlayer);

            if (distanceToPlayer <= interactRange)
            {
                // Set the isTalking bool to true
                isTalking = true;
            }
            else
            {
                // Set the isTalking bool to false when the player is out of range
                isTalking = false;
            }
        }
        else
        {
            // Debug log if player is null
            Debug.Log("Player not found!");
        }
        Peasantgirl.SetBool("isTalking", isTalking);
    }
}

