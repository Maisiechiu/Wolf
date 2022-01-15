using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusic : MonoBehaviour
{
    public GameObject TitleBGM;
    GameObject BGM = null;
    // Start is called before the first frame update
    void Start()
    {
        BGM = GameObject.FindGameObjectWithTag("Sound");
        Debug.Log(BGM);
        if (BGM == null) 
        {
            BGM = Instantiate(TitleBGM);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
