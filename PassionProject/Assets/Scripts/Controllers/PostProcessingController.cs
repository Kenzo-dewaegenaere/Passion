using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class PostProcessingController : MonoBehaviour
{


    private bool triggeringReset;
    private bool triggeringTrip;

    public GameObject State;
    public GameObject HelpState;

    public GameObject Chests;

    public GameObject interactionText;

    public Volume vol;
    private Vignette vg;
    public float targetVg = 1f;


    public float AmountEated;

    void Awake()
    {
    }

    void Update()
    {


        //get the ColorAdjustment probably a good idea to check if it is null, I was lazy.

        vol.profile.TryGet(out vg);

        //set the new values

        vg.intensity.value = AmountEated + .5f;


        if (triggeringTrip)
        {

            interactionText.transform.GetChild(0).gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {

                State.transform.GetChild(0).gameObject.SetActive(true);
                State.transform.GetChild(1).gameObject.SetActive(true);
                AmountEated = AmountEated + .1f;

            }
            if(AmountEated > .2f)
            {
                HelpState.gameObject.SetActive(true);
            }

            if (AmountEated > .09f)
            {
                Chests.gameObject.SetActive(true);
            }

        }
        else
        {
            interactionText.transform.GetChild(0).gameObject.SetActive(false);
        }


        if (triggeringReset)
        {

            interactionText.transform.GetChild(1).gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {

                State.transform.GetChild(0).gameObject.SetActive(false);
                State.transform.GetChild(1).gameObject.SetActive(false);
                
                AmountEated = 0f;

                Chests.gameObject.SetActive(false);



            }

        }
        else
        {
            interactionText.transform.GetChild(1).gameObject.SetActive(false);
        }


    }

    

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "IsTrip")
        {
            triggeringTrip = true;
        }

        if (other.tag == "IsReset")
        {
            triggeringReset = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "IsTrip")
        {
            triggeringTrip = false;
        }

        if (other.tag == "IsReset")
        {
            triggeringReset = false;
        }
    }

}
