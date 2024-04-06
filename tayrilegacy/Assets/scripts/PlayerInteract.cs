using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private GameObject interactText;
    [SerializeField] private float interactRange = 2f;

    private bool interacting = false;

    private void Update()
    {
        if (!interacting)
        {
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);

            bool interactableInRange = false;

            foreach (Collider collider in colliderArray)
            {
                if (collider.TryGetComponent(out NPCInteractable npcInteractable))
                {
                    interactableInRange = true;
                    break;
                }
            }

            interactText.SetActive(interactableInRange);

            if (Input.GetKeyDown(KeyCode.E) && interactableInRange)
            {
                interacting = true;
                InteractWithNPC(colliderArray);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                interacting = false;
                interactText.SetActive(false);
            }
        }
    }

    private void InteractWithNPC(Collider[] colliderArray)
    {
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out NPCInteractable npcInteractable))
            {
                npcInteractable.Interact();
                break;
            }
        }
    }
}

