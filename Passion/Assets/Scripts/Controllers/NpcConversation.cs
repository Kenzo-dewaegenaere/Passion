using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcConversation : MonoBehaviour
{

    private GameObject triggeringNpc;
    private bool triggering;
    private bool interacting;

    public GameObject npcText;

    public int whatSound;

    void Update()
    {
        if (triggering)
        {



            if (triggering && !interacting)
            {
                npcText.SetActive(true);
            }

            if (!interacting && Input.GetKeyDown(KeyCode.Q))
            {
                interacting = true;
                npcText.SetActive(false);
            }

            if (triggering && interacting)
            {

                npcText.SetActive(false);
                AudioManagerController.PlaySound(whatSound);
                interacting = false;
            }

        }
        else
        {
            npcText.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            triggering = true;
            triggeringNpc = other.gameObject;

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            triggering = false;
            interacting = false;
            triggeringNpc = null;

        }
    }



}