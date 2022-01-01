using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockerController : MonoBehaviour
{
	public GameObject closedSafe;
    public GameObject openedSafe;
    Canvas lockerCanvas;
	public static bool isSafeOpened = false;
    // Start is called before the first frame update
    void Start()
    {
        closedSafe.SetActive (true);
		openedSafe.SetActive (false);
        lockerCanvas = GameObject.Find("lockerCanvas").GetComponent<Canvas>();
        lockerCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSafeOpened) {
            //Debug.Log("locker Password true");
			lockerCanvas.enabled = false;
			closedSafe.SetActive (false);
			openedSafe.SetActive (true);
		}
    }
    void OnMouseDown()
    {
        
        Debug.Log("mouse click");
        lockerCanvas.enabled = true;

    }
}
