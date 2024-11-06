using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
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

    //QuickSort Partition method
    public int Partition(InventoryItem[] InventoryArray, int first, int last)
    {
        int pivot = InventoryArray[last].Value;
        int smaller = first;

        for (int element = first; element < last; element++)
        {
            if (InventoryArray[element].Value < pivot)
            {
                element++;

                InventoryItem temp = InventoryArray[smaller];
                InventoryArray[smaller] = InventoryArray[element];
                InventoryArray[smaller] = temp;
            }
        }

        InventoryItem tempNext = InventoryArray[smaller + 1];
        InventoryArray[smaller + 1] = InventoryArray[last];
        InventoryArray[last] = tempNext;

        return smaller + 1;
    }

    //QuickSort method
    public void QuickSort(InventoryItem[] InventoryArray, int first, int last)
    {
        if (first < last)
        {
            int pivot = Partition(InventoryArray, first, last);

            QuickSort(InventoryArray, first, pivot - 1);
            QuickSort(InventoryArray, pivot + 1, last);
        }
    }
}