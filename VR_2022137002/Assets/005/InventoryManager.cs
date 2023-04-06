using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item                                  
{
    public string itemName;
    public int itemID;
    public int itemCount;
}

public class InventoryManager : MonoBehaviour
{
    public Dictionary<int, Item> inventory = new Dictionary<int, Item>();                      
    public void AddItem(Item newItem)                                                      
    {
        if (inventory.ContainsKey(newItem.itemID))                                           
        {
            inventory[newItem.itemID].itemCount += newItem.itemCount;                       
        }
        else
        {
            inventory.Add(newItem.itemID, newItem);                                        
        }

    }
    public void RemoveItem(int itemID, int count = 1)                                       
    {
        if (inventory.ContainsKey(itemID))                                                                                          
        {
            inventory[itemID].itemCount -= count;                                            

            if (inventory[itemID].itemCount <= 0)                                            
            {
                inventory.Remove(itemID);
            }
        }
    }
    public Item GetItem(int itemID)
    {
        if (inventory.ContainsKey(itemID))                                                                                          
        {
            return inventory[itemID];
        }
        else
        {
            return null;
        }
    }

    public void PrintInventory()
    {
        foreach (KeyValuePair<int, Item> item in inventory)                                      
        {
            Debug.Log("Item: " + item.Value.itemName + " , Count : " + item.Value.itemCount);
        }
    }
}
