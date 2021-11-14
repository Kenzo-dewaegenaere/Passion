using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    public GameObject inventoryUI;
    void Update()
    {
        

        //open the inventory on I press
        if (Input.GetKeyDown(KeyCode.I))
            {
                inventoryUI.SetActive(true);
             }


        //close the inventory on O press
        if (Input.GetKeyDown(KeyCode.O))
        {
            inventoryUI.SetActive(false);
        }

    }

}

  

