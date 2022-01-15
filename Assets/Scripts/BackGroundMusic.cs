using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackGroundMusic : MonoBehaviour
{
    void Awake()
    {

        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("backgroudMusic");

    }

    // Update is called once per frame
    void Update()
    {


    }
}
