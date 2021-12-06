using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class PostProcessingController : MonoBehaviour
{


    private bool triggering;

    public GameObject State;

    public GameObject interactionText;

    //[Header("Health")]
    //public int currentPlayerHealth;


    //public Volume vol;

    //private Vignette vg;

    //private float curentVg = 0;

    //public float targetVg = 1f;

    //public float healthToFloat;

    void Awake()
    {
    }

    void Update()
    {

        ////int to float
        //healthToFloat = (float)currentPlayerHealth;

        ////normalize
        //healthToFloat = (healthToFloat / 100f) * -1 + 1;

        ////get the ColorAdjustment probably a good idea to check if it is null, I was lazy.

        //vol.profile.TryGet(out vg);

        ////access the current values

        //curentVg = vg.intensity.value;

        ////set the new values

        //vg.intensity.value = healthToFloat +.3f;

        if (triggering)
        {
            interactionText.SetActive(true);


            if (Input.GetKeyDown(KeyCode.E))
            {

                if (gameObject.CompareTag("IsReset"))
                {
                    Debug.Log("The tag for this GameObject is" + gameObject.tag);
                }

                if (gameObject.CompareTag("IsTrip"))
                {

                    State.transform.GetChild(0).gameObject.SetActive(true);
                    State.transform.GetChild(1).gameObject.SetActive(true);

                }



            }

        }
        else
        {
            interactionText.SetActive(false);

        }
    


}


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "IsPlayer")
        {

            triggering = true;


        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "IsPlayer")
        {
            triggering = false;

        }
    }

}
