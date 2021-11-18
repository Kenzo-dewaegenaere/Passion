using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour, InventoryItems
{

    //declare the name
    public string Name
    {
        get
        {
            return "Test";
        }
    }

    public Sprite _Image = null;


    //declare the image
    public Sprite Image
    {
        get
        {
            return _Image;
        }
    }

    public void OnPickup()
    {

        //disable the object so it doesn't appear
        gameObject.SetActive(false);
    }

}
