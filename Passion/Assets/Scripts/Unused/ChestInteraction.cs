using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteraction : MonoBehaviour
{

    private GameObject triggeringChest;
    private bool triggering;    

    public GameObject interactionText;

    public GameObject inventoryUI;



    void Update()
    {
        if (triggering)
        {
             interactionText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                interactionText.SetActive(false);
                Debug.Log("Open chest");
                inventoryUI.SetActive(true);


            }

        }
        else
        {
            interactionText.SetActive(false);
            inventoryUI.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "chest")
        {
            triggering = true;
            triggeringChest = other.gameObject;
            Debug.Log("in radius");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "chest")
        {
            triggering = false;
            triggeringChest = null;
            Debug.Log("out radius");
        }
    }



}
