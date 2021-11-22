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
        test = Resources.Load<AudioClip>("TestSound");
        audioSrc = GetComponent<AudioSource>();
        
    }

  public static void PlaySound()
    {
        audioSrc.PlayOneShot(test);
    }
}
