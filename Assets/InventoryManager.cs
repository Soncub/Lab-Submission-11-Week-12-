using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
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

        //QuickSort called;
        SortbyValue(InventoryArray, 0, InventoryArray.Length - 1);
 
        //QuickSortByValue(InventoryArray, 0, InventoryArray.Length - 1);

        //Debug.Log("Inventory sorted by value:");
        //for (int i = 0; i < InventoryArray.Length; i++)
        //{
        //    Debug.Log(InventoryArray[i].Name);
        //}
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

    //QuickSort method
    public void QuickSortByValue(InventoryItem[] InventoryArray, int first, int last)
    {
        if (first < last)
        {
            int pivot = PartitionByValue(InventoryArray, first, last);

            QuickSortByValue(InventoryArray, first, pivot - 1);
            QuickSortByValue(InventoryArray, pivot + 1, last);
        }
    }
    
    //QuickSort Partition method
    public int PartitionByValue(InventoryItem[] InventoryArray, int first, int last)
    {
        int pivot = InventoryArray[last].Value;
        int smaller = first - 1;
         
        for (int element = first; element < last; element++)
        {
            if (InventoryArray[element].Value > pivot)
            {
                InventoryItem temp = InventoryArray[element];
                InventoryArray[element] = InventoryArray[element + 1];
                InventoryArray[element + 1] = temp; 
            }
        }

        Debug.Log("Partitioned Inventory:");
        for (int i = 0; i < InventoryArray.Length; i++)
        {
            Debug.Log(InventoryArray[i].Name);
        }

        return pivot;
    }

    //SimpleSort method
    public void SortbyValue(InventoryItem[] InventoryArray,  int first, int last)
    {
        for (int element = first; element < last; element++)
        {
            if (InventoryArray[element].Value > InventoryArray[last].Value)
            {
                InventoryItem temp = InventoryArray[last];
                InventoryArray[last] = InventoryArray[element];
                InventoryArray[element] = temp;
            }
        }

        Debug.Log("Partitioned Inventory:");
        for (int i = 0; i < InventoryArray.Length; i++)
        {
            Debug.Log(InventoryArray[i].Name);
        }
    }

    
}