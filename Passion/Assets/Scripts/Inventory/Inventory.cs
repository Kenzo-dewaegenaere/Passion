using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    //pre-defined slots
    private const int slots = 9;

    //create new list
    private List<InventoryItems> listItems = new List<InventoryItems>();


    //public event to add items
    public event EventHandler<InventoryEventArgs> ItemAdded;

    //Function
    public void AddItem(InventoryItems item)
    {

        //if there are less items then slots
        if (listItems.Count < slots)
        {

            //get the colider component and check if enebled
            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();
            if (collider.enabled)
            {

                listItems.Add(item);
                item.OnPickup();

                if(ItemAdded != null)
                {
                    ItemAdded(this, new InventoryEventArgs(item));
                }
            }
        }
    }
}
