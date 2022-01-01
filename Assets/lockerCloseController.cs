using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockerCloseController : MonoBehaviour
{
    Canvas lockerCanvas;
    
    // Start is called before the first frame update
    void Start()
    {
        lockerCanvas = GameObject.Find("lockerCanvas").GetComponent<Canvas>();

        //bookCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloselockerCanvas()
    {
        lockerCanvas.enabled = false;
    }
}
