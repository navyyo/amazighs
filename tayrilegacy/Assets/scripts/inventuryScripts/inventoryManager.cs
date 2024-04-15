using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryManager : MonoBehaviour
{
    public static inventoryManager Instance;
    public List<Item> items = new List<Item>();

    public Transform itemContent;
    public GameObject inventoryItem;
    public Toggle enableRemove;
    public inventoryItem[] inventoryItems;
    private void Awake() {
        Instance = this;
    }

    public void Add(Item item)
    {
        items.Add(item);
    }
    public void Remove(Item item)
    {
        items.Remove(item);
    }
    public void ListItems()
    {
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in items)
        {
            GameObject obj = Instantiate(inventoryItem, itemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            var removeButton = obj.transform.Find("removeButton").gameObject;

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;

            if (enableRemove.isOn)
            {
                removeButton.SetActive(true);
            }
        }
        setInventoryItems();
    }
    public void EnableItemsRemove()
    {
        if (enableRemove.isOn)
        {
            foreach (Transform item in itemContent)
            {
                item.Find("removeButton").gameObject.SetActive(true);
            }
        }else
        {
            foreach (Transform item in itemContent)
            {
                item.Find("removeButton").gameObject.SetActive(false);
            }
        }
    }
    public void setInventoryItems()
    {
        inventoryItems = itemContent.GetComponentsInChildren<inventoryItem>();
        for (int i = 0; i< items.Count; i++)
        {
            inventoryItems[i].AddItem(items[i]);
        }
    }
}
