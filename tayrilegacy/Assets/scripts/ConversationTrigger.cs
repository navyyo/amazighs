using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class ConversationTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private NPCConversation myConversation;
    private void OnTriggerStay(Collider other)
    {
        if (other .CompareTag("Player"))
        {
            if(Input.GetKeyDown(KeyCode.E)) 
            {ConversationManager.Instance.StartConversation(myConversation);}
        }
    }
}
