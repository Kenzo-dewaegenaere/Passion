using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject triggeringChest;
    private bool triggering;

    public GameObject interactionText;
    public Animator anim;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (triggering)
        {
            interactionText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Q))
            {
                interactionText.SetActive(false);
                Debug.Log("Open chest");
                anim.Play("Animated PBR Chest _Opening_UnCommon");


            }

        }
        else
        {
            interactionText.SetActive(false);
            
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            triggering = true;
            triggeringChest = other.gameObject;
            Debug.Log("in radius");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            triggering = false;
            triggeringChest = null;
            Debug.Log("out radius");
        }
    }
}
