using System;
using UnityEngine;

public class PlayerInteract : MonoBehaviour , IKitchenObjectParent
{
    public static PlayerInteract Instance {  get; private set; }
    public event EventHandler <OnSelectedCounterChangedEventArgs> OnSelectedCounterChanged;
    public class OnSelectedCounterChangedEventArgs : EventArgs
    {
        public BaseCounter selectedCounter;
    }

    [SerializeField] private GameInput gameInput;
    [SerializeField] private GameObject interactText;
    [SerializeField] private float interactRange = 2f;
    [SerializeField] private LayerMask countersLayerMask;
    private BaseCounter selectedCounter;
    [SerializeField] private Transform counterTopPoint;
    private KitchenObject kitchenObject;
    [SerializeField] private Animator animator;

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
       if (selectedCounter != null) { selectedCounter.Connect(this);
            if (animator != null)
            {
                animator.SetBool("Pickupitem", true);
            }
        }
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
            if (raycastHit.transform.TryGetComponent(out BaseCounter baseCounter))
            {
                if(baseCounter != selectedCounter)
                {
                    SetSelectedCounter(baseCounter);
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
    private void SetSelectedCounter( BaseCounter selectedCounter)
    {
        this.selectedCounter = selectedCounter;
        OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArgs { selectedCounter = selectedCounter });
    }
    public Transform GetKitchenObjectFollowTransform()
    {
        return counterTopPoint;
    }
    public void SetKitchenObject(KitchenObject kitchenObject)
    {   
        this.kitchenObject = kitchenObject;
    }
    public KitchenObject GetKitchenObject() { return kitchenObject; }
    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }
    public bool HasKitchenObject()
    {  
        return kitchenObject != null;
    }
    
}

