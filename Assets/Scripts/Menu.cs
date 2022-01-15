using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{   
    Canvas ManualCanvas;
    Canvas MenuCanvas;
    bool finish;
    private void Start()
    {
        ManualCanvas = GameObject.Find("ManualCanvas").GetComponent<Canvas>();
        MenuCanvas = GameObject.Find("Menu").GetComponent<Canvas>();
        ManualCanvas.enabled = false;
        MenuCanvas.enabled = true;



    }
    private void Update()
    {
        finish = MyVideo.finish;
    }
    public void clickStartButton()
    {
        //PlayerPrefs.SetString("Milestone", "Spawn");
        PlayerPrefs.SetString("Milestone", "oneScene");
        MenuCanvas.enabled = false;
        MyVideo.play = true;
    
    }

    public void clickLoadButton()
    {
        //SceneManager.LoadScene(PlayerPrefs.GetString("Milestone"));
        SceneManager.LoadScene("oneScene");

    }

    public void clickQuitButton()
    {
        Application.Quit();
    }

    public void LoadManual()
    {
        ManualCanvas.enabled = true;
    }

    public void CloseManual()
    {
        ManualCanvas.enabled = false;
    }
}
