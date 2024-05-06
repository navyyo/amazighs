using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{

    [SerializeField] private KitchenObjectSO kitchenObjectSO;
   private IKitchenObjectParent kitchenObjectParent;
    public KitchenObjectSO GetKitchenObjectSO() { return kitchenObjectSO; }
    public void SetKitchenObjectParent(IKitchenObjectParent kitchenObjectParent)
    {
        this.kitchenObjectParent = kitchenObjectParent;
       transform.parent =kitchenObjectParent.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }
    public IKitchenObjectParent  GetKitchenObjectParent()
    {
        return kitchenObjectParent;
    }
}
