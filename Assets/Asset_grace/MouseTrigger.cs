using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class MouseTrigger : MonoBehaviour
{

    Canvas bookCanvas;
    void Start()
    {
        bookCanvas = GameObject.Find("bookCanvas").GetComponent<Canvas>();
        bookCanvas.enabled = false;
    }
    void OnMouseDown()
    {
        Debug.Log("Mouse Down");
        bookCanvas.enabled = true;

    }
}
