using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.VersionControl;
using UnityEngine;

public class InvenController : MonoBehaviour
{
    public GameObject inventory;
    public bool inventoryIsClosed;
    inventoryManager inventoryManager;
    void Start()
    {
        inventoryIsClosed = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("i"))
        {
            if(inventoryIsClosed == true)
            {
                inventory.SetActive(true);
                inventoryIsClosed = false;
                inventoryManager.ListItems();
            }
            else
            {
                inventory.SetActive(false);
                inventoryIsClosed = true;
            }
        }
    }
}
