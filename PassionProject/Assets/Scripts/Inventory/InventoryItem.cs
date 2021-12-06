using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface InventoryItems
{
    string Name { get; }
    Sprite Image { get; }

    void OnPickup();
}

    public class InventoryEventArgs: EventArgs
    {
        public InventoryEventArgs(InventoryItems item)
        {
            Item = item;
        }

        public InventoryItems Item;
    }

