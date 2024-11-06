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
    public int searchID;

    private void Start()
    {
        int result = LinearSearchByName(searchName);
        if (result != -1)
        {
            Debug.Log("Linear Search Result: " + InventoryArray[result].Name);
        }
        else
        {
            Debug.Log("No Result Found for Linear Search!");
        }

        result = BinarySearchByID(searchID);
        if (result != -1)
        {
            Debug.Log("Binary Search Result: " + InventoryArray[result].Name);
        }
        else
        {
            Debug.Log("No Result Found for Binary Search!");
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

    // Binary Search Method
    int BinarySearchByID(int itemID)
    {
        if (InventoryArray.Length == 0)
        {
            Debug.Log("No Array Declared.");
            return -1;
        }
        int left = 0;
        int right = InventoryArray.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (InventoryArray[mid].ID == itemID)
            {
                return mid;
            }
            else if (InventoryArray[mid].ID < itemID)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return -1;
    }
}