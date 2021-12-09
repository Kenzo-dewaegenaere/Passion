using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestHandlerUi : MonoBehaviour
{


    [Header("Quest Steps")]
    public GameObject Dialogue;
    public GameObject First;
    public GameObject Second;
    public GameObject Last;

    [Header("Quest Progress")]
    public GameObject LookState;

    void Update()
    {
        QuestUpdate();
    }

    void QuestUpdate()
    {

        if (!LookState.GetComponent<NpcConversation>().getFirst() && !LookState.GetComponent<NpcConversation>().getLast()) {

            First.SetActive(true);

        }else if (LookState.GetComponent<NpcConversation>().getFirst() && !LookState.GetComponent<NpcConversation>().getLast())
        {
            First.SetActive(false);
            Second.SetActive(true);
        }
        else if (LookState.GetComponent<NpcConversation>().getLast())
        {
            Last.SetActive(true);
            Second.SetActive(false);
        }

       
    }
}
