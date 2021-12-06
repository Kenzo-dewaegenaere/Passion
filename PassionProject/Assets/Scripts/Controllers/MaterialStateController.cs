using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialStateController : MonoBehaviour
{

    public Material[] material;
    public int x;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        x = 0;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[x];
        
    }

    // Update is called once per frame
    void Update()
    {
        rend.sharedMaterial = material[x];

        NextColor();
    }


    public void NextColor()
    {

        if (Input.GetMouseButtonDown(0))
        {
            x = 2;

        }
        else if(Input.GetMouseButtonDown(1))
        {
            x = 0;
        }
    }
}
