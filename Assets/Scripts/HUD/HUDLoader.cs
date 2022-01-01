using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDLoader : MonoBehaviour
{
    static int collected;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("HUD", LoadSceneMode.Additive);
    }
    
}
