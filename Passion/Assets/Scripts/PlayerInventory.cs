using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    public GameObject inventoryUI;
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.I))
            {
                inventoryUI.SetActive(true);
             }

        if (Input.GetKeyDown(KeyCode.O))
        {
            inventoryUI.SetActive(false);
        }

    }

}

  

