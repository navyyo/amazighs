using System;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public static PlayerInteract Instance {  get; private set; }
    public event EventHandler <OnSelectedCounterChangedEventArgs> OnSelectedCounterChanged;
    public class OnSelectedCounterChangedEventArgs : EventArgs
    {
        public ClearCounter selectedCounter;
    }

    [SerializeField] private GameInput gameInput;
    [SerializeField] private GameObject interactText;
    [SerializeField] private float interactRange = 2f;
    [SerializeField] private LayerMask countersLayerMask;
    private ClearCounter selectedCounter;

    private bool interacting = false;
    private void Awake()
    { if(Instance != null)
        {
            Debug.Log("theres more than one player instance");
        }
        Instance = this;
    }

    private void Start()
    {
        gameInput.OnInteractAction += GameInput_OnInteractAction;
    }

    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
       if (selectedCounter != null) { selectedCounter.Connect(); }
    }

    private void Update()
    {
        InteractByConversation();
        HandleInteractions();
    }

    private void HandleInteractions()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit raycastHit, interactRange, countersLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out ClearCounter clearCounter))
            {
                if(clearCounter != selectedCounter)
                {
                    SetSelectedCounter(clearCounter);
                }
                
            }else {
                SetSelectedCounter(null);
            }
        } else {
            SetSelectedCounter(null);
        }

       
    }
    private void InteractByConversation() {
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
    private void SetSelectedCounter( ClearCounter selectedCounter)
    {
        this.selectedCounter = selectedCounter;
        OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArgs { selectedCounter = selectedCounter });
    }
}

