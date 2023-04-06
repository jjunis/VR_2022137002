using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;                                            

public class InventoryExample : MonoBehaviour
{
    public InventoryManager inventoryManager;                   

    // Start is called before the first frame update
    void Start()
    {
        Item apple = new Item { itemName = "Apple", itemID = 1, itemCount = 3 };        
        Item banana = new Item { itemName = "Banana", itemID = 2, itemCount = 5 };
        Item orange = new Item { itemName = "Orange", itemID = 3, itemCount = 2 };

        inventoryManager.AddItem(apple);                
        inventoryManager.AddItem(banana);
        inventoryManager.AddItem(orange);

        inventoryManager.PrintInventory();             

        inventoryManager.RemoveItem(2, 3);

        inventoryManager.PrintInventory();

        var sortedByVaule = inventoryManager.inventory.OrderBy(pair => pair.Value.itemCount).ToDictionary
            (pair => pair.Value.itemName, pair => pair.Value.itemCount);                  

        foreach (KeyValuePair<string, int> entry in sortedByVaule)
        {
            Debug.Log("Key : " + entry.Key + " Value : " + entry.Value);        
        }
    }
}
