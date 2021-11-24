using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerController : MonoBehaviour
{

    public static AudioClip test;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        test = Resources.Load<AudioClip>("test");
        audioSrc = GetComponent<AudioSource>();

    }

    public static void PlaySound(int whatSound)
    {

        switch (whatSound)
        {
            case 1:
                audioSrc.PlayOneShot(test);
                break;

            default:
                break;
        }


    }
}