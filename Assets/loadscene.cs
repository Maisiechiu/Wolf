using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class loadscene : MonoBehaviour
{
    // Start is called before the first frame update
    //Scene completed:1 4 35 7 8 11
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("oneScene");
        }
        if (Input.GetKey(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("oneScene");
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            SceneManager.LoadScene("fourScene");
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            SceneManager.LoadScene("threeandfiveScene");
        }
        if (Input.GetKey(KeyCode.Alpha7))
        {
            SceneManager.LoadScene("sevenScene");
        }
        if (Input.GetKey(KeyCode.Alpha8))
        {
            SceneManager.LoadScene("eightScene");
        }
        if (Input.GetKey(KeyCode.Alpha9))
        {
            SceneManager.LoadScene("elevenScene");
        }
        if(PlayEnding.finish_ending)
        {
            PlayEnding.finish_ending = false;
            SceneManager.LoadScene("Menu");
        }


    }
}
