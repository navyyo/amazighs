using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClearCounter : MonoBehaviour

{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Vector3 spawnPosition;
    private KitchenObject kitchenObject;
    [SerializeField] private ClearCounter secondClearCounter;
    [SerializeField] private bool testing;

    private void Update()
    {
        if(testing && Input.GetKeyUp(KeyCode.T))
        {
            if (kitchenObject != null)
            {
                kitchenObject.SetClearCounter(secondClearCounter);
                Debug.Log(kitchenObject.GetClearCounter());
            }
        }
    }
    public void Connect()
    {
        if (kitchenObject == null)
        {
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, spawnPosition, Quaternion.identity);
            kitchenObject = kitchenObjectTransform.GetComponent<KitchenObject>();
             kitchenObject.SetClearCounter(this);
         }
         else { Debug.Log(kitchenObject.GetClearCounter()); }
    }
  

}

