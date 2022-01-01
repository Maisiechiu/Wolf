using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class buttonController : MonoBehaviour
{

    Canvas bookCanvas;
    
    // Start is called before the first frame update
    void Start()
    {
        bookCanvas = GameObject.Find("bookCanvas").GetComponent<Canvas>();

        //bookCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseBookCanvas()
    {
        bookCanvas.enabled = false;
    }

}
