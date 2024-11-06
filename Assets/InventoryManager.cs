using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class InventoryManager : MonoBehaviour
{
    // Array of Items initialized in editor.
    public InventoryItem[] InventoryArray;
    // Name to search for with Linear Search
    public string searchName;

    private void Start()
    {
        int result = LinearSearchByName(searchName);
        if (result != -1)
        {
            Debug.Log("Linear Search Result: " + InventoryArray[result].Name);
        }
        else
        {
            Debug.Log("No Result Found!");
        }
    }

    // Linear Search Method
    int LinearSearchByName(string itemName)
    {
        for (int i = 0; i < InventoryArray.Length; i++)
        {
            if (InventoryArray[i].Name == itemName)
                return i;
        }
        return -1;
    }
}