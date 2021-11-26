using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class PostProcessingController : MonoBehaviour
{


    [Header("Health")]
    public int currentPlayerHealth;
    

    public Volume vol;

    private Vignette vg;

    private float curentVg = 0;

    public float targetVg = 1f;

    public float healthToFloat;

    void Awake()
    {
    }

    void Update()
        {


            healthToFloat = (float)currentPlayerHealth;

            healthToFloat = (healthToFloat / 100f) *-1 +1;

            //get the ColorAdjustment probably a good idea to check if it is null, I was lazy.

            vol.profile.TryGet(out vg);

             //access the current values

             curentVg = vg.intensity.value;

             //set the new values

             vg.intensity.value = healthToFloat;

           

            

        }

}
