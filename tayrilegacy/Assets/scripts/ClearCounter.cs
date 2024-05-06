using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClearCounter : MonoBehaviour, IKitchenObjectParent

{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform counterTopPoint;
        
    private KitchenObject kitchenObject;
    [SerializeField] private ClearCounter secondClearCounter;
    [SerializeField] private bool testing;

    private void Update()
    {
        if(testing && Input.GetKeyUp(KeyCode.T))
        {
            if (kitchenObject != null)
            {
                kitchenObject.SetKitchenObjectParent(secondClearCounter);
                Debug.Log(kitchenObject.GetKitchenObjectParent());
            }
        }
    }
    public void Connect(PlayerInteract player)
    {
        if (kitchenObject == null)
        {
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
            kitchenObjectTransform.localPosition = Vector3.zero;
            kitchenObject = kitchenObjectTransform.GetComponent<KitchenObject>();
            kitchenObject.SetKitchenObjectParent(this);
         }
         else { Debug.Log(kitchenObject.GetKitchenObjectParent());
            kitchenObject.SetKitchenObjectParent(player);
        }
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

