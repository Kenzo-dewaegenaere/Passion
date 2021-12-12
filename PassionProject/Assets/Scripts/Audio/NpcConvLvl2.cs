using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcConvLvl2 : MonoBehaviour
{


    public AudioClip Final;
    public GameObject GoNext;

   

    void Update()
    {
        //Debug.Log(lastTalkedAt + cooldown);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "IsPlayer")
        {

                AudioSource audio = GetComponent<AudioSource>();
                audio.PlayOneShot(Final);

                GoNext.GetComponent<GoNextScene>().NextScene();


        }
    }


}
