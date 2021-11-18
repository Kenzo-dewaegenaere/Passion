using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcConversation : MonoBehaviour
{

    private GameObject triggeringNpc;
    private bool triggering;

    public GameObject npcText;

     void Update()
    {
        if (triggering)
        {
            npcText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("interacting");
            }
        }
        else
        {
            npcText.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "NPC")
        {
            triggering = true;
            triggeringNpc = other.gameObject;
            Debug.Log("in radius");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "NPC")
        {
            triggering = false;
            triggeringNpc = null;
            Debug.Log("out radius");
        }
    }



}
