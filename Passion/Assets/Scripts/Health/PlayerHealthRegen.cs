using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthRegen : MonoBehaviour
{

    private GameObject triggeringCrystal;
    private bool triggering;

    public GameObject interactionText;

    public GameObject playerHealth;
    private PlayerController currentPlayerHealth;

    private void Start()
    {
        currentPlayerHealth = playerHealth.GetComponent<PlayerController>();
    }

    void Update()
    {
        if (triggering)
        {
            interactionText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Q))
            {
                interactionText.SetActive(false);
                currentPlayerHealth.currentPlayerHealth = 100;

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
            triggeringCrystal = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            triggering = false;
            triggeringCrystal = null;
        }
    }

}
