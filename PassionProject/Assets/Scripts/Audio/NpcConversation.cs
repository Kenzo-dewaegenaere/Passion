using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcConversation : MonoBehaviour
{

    private GameObject triggeringNpc;
    private bool triggering;
    private bool interacting;

    public AudioManagerControllerNpcOne Sound; 

    public GameObject npcText;

    public Transform player;


    public AudioClip Intro;
    public AudioClip Tips;
    public AudioClip Final;

    private void Awake()
    {

        player = GameObject.Find("Player").transform;

    }
    void Update()
    {
        transform.LookAt(player);

        if (triggering)
        {

            if (triggering && !interacting)
            {
                npcText.SetActive(true);
            }

            if (!interacting && Input.GetKeyDown(KeyCode.E))
            {
                interacting = true;
                npcText.SetActive(false);
            }

            if (triggering && interacting)
            {

                AudioSource audio = GetComponent<AudioSource>();
                audio.PlayOneShot(Tips);

                npcText.SetActive(false);
                
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
        if (other.tag == "IsPlayer")
        {
            triggering = true;
            triggeringNpc = other.gameObject;

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "IsPlayer")
        {
            triggering = false;
            interacting = false;
            triggeringNpc = null;

        }
    }



}