using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    public Inventory Inventory;


    public GameObject InventoryUI;

    void Start()
    {

        Inventory.ItemAdded += UpdateItemAdded;
                
    }

    void Update()
    {
        InventoryState();
    }

    public bool inventoryToggle = true;

    void InventoryState()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (inventoryToggle)
            {
                
                InventoryUI.SetActive(true);
                inventoryToggle = false;
            }
            else {
                InventoryUI.SetActive(false);
                inventoryToggle = true;
            }

        }

    }



    private void UpdateItemAdded(object sender, InventoryEventArgs e)
    {

        //find the inventory ui postion
        Transform Inventory = transform.Find("InventoryUI");

        //loop around the inventory slots
        foreach (Transform slot in Inventory)
        {

            //find the image place inside the ui
            Image image = slot.GetChild(0).GetComponent<Image>();

            //if there is none and there is an item picked up
            if (!image.enabled)
            {

                //enable the image script and add the item sprite to the ui
                image.enabled = true;
                image.sprite = e.Item.Image;

                break;
            }
        }
    }


}