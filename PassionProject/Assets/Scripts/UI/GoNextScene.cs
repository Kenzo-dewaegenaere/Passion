using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoNextScene : MonoBehaviour
{
    public GameObject NextSceneUI;

    public void NextScene()
    {
        NextSceneUI.SetActive(true);
        Time.timeScale = 0f;

    }
}