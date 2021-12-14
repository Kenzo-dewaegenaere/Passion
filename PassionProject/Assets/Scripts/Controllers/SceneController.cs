using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;


public class SceneController : MonoBehaviour
{

    //public RenderPipelineAsset exampleAssetA;

    void Awake()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void NextScene()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitApp()
    {
        Application.Quit();
    }

}
