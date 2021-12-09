using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcFlofloSounds : MonoBehaviour
{
    public GameObject npcText;


    public AudioClip FloFlo;

    //delay
    public float cooldown = 30.3f; //seconds
    private float lastTalkedAt = -9999f;

    private bool IsTalking = false;

    void Update()
    {
        //Debug.Log(lastTalkedAt + cooldown);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "IsPlayer")
        {

            if (!IsTalking)
            {
                AudioSource audio = GetComponent<AudioSource>();
                audio.PlayOneShot(FloFlo);

                IsTalking = true;
                lastTalkedAt = Time.time;
            }
            if (Time.time > lastTalkedAt + cooldown)
            {
                IsTalking = false;
            }

           

        }
    }


}


