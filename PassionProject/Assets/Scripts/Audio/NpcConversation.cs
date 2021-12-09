using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcConversation : MonoBehaviour
{

    private GameObject triggeringNpc;
    private bool triggering;
    private bool interacting;


    public GameObject IsFound;

    public GameObject npcText;

    public Transform player;

    [Header("Audio files")]
    public AudioClip Intro;
    public AudioClip Tips;
    public AudioClip Final;

    [Header("Dialogue files")]
    public GameObject Dialogue;
    public GameObject First;
    public GameObject Second;
    public GameObject Last;



    [Header("Barrier")]
    public GameObject Barrier;

    private bool intro = false;

    private bool IsPlayed = false;
    private bool IntroPlayed = false;
    private bool IsDone = false;


    private void Awake()
    {

        player = GameObject.Find("Player").transform;

    }
    void Update()
    {

        transform.LookAt(player);

        if (triggering)
        {

            if (!interacting)
            {
                npcText.SetActive(true);
            }

            if (!interacting && Input.GetKeyDown(KeyCode.E))
            {
                interacting = true;
                npcText.SetActive(false);
                Dialogue.SetActive(true);
                Barrier.GetComponent<Collider>().isTrigger = true;

                if (intro)
                {
                    IntroPlayed = true;
                }
            }

            if (triggering && interacting)
            {
                AudioSource audio = GetComponent<AudioSource>();

                if (!intro)
                {

                    interacting = false;
                    audio.PlayOneShot(Intro);

                    npcText.SetActive(false);

                    
                    intro = true;

                    //dialogue handling
                    First.SetActive(true);
                    Second.SetActive(false);
                    Last.SetActive(false);
                }
                else if (intro && !IsPlayed && !IsFound.GetComponent<PlayerMovementController>().getBool())
                {

                    audio.PlayOneShot(Tips);

                    npcText.SetActive(false);

                    interacting = false;


                    //dialogue handling
                    First.SetActive(false);
                    Second.SetActive(true);
                    Last.SetActive(false);
                    IsPlayed = true;

                }
                else if(IntroPlayed && !IsDone && IsFound.GetComponent<PlayerMovementController>().getBool())
                {
                    audio.PlayOneShot(Final);

                    npcText.SetActive(false);

                    interacting = false;
                    IsDone = true;

                    //dialogue handling
                    First.SetActive(false);
                    Second.SetActive(false);
                    Last.SetActive(true);
                }

            }

        }
        else
        {
            npcText.SetActive(false);
            Dialogue.SetActive(false);
            IsPlayed = false;
            
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


    public bool getFirst() { return intro; }
    public bool getLast() { return IsFound.GetComponent<PlayerMovementController>().getBool(); }


}