using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private GameObject triggeringItem;
    private bool triggering;

    public GameObject interactionText;




    void Update()
    {
        if (triggering)
        {
            interactionText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                interactionText.SetActive(false);
                Debug.Log("Pick up item");

                Destroy(gameObject);


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
            triggeringItem = other.gameObject;
            Debug.Log("in radius");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            triggering = false;
            triggeringItem = null;
            Debug.Log("out radius");
        }
    }
}
