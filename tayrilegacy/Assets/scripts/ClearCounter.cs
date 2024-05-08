using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClearCounter : BaseCounter

{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;




    public override void Connect(PlayerInteract player)
    {
        if (!HasKitchenObject())

        {
            Debug.Log("empty counter");
            if (player.HasKitchenObject())
            {



                Debug.Log("Player does have a kitchen object.");

            } else
            {

                Debug.Log("Player empty handed");
            }
        }
       
        
    }

}

