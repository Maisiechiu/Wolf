using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    static bool oneToThree = false;
    static bool fourToThree = false;
    static bool eightToThree = false;
    static bool threeToOne = false;
    static bool threeToFour = false;
    static bool threeToEight = false;
    Scene m_scene;
    void Start()
    {
        m_scene = SceneManager.GetActiveScene();
        if(oneToThree) gameObject.transform.position = new Vector2(-26.6f,6f);
        if(fourToThree) gameObject.transform.position = new Vector2(-26.6f,18f);
        if(eightToThree) gameObject.transform.position = new Vector2(-17.7f,-5f);
        if(threeToOne){
            gameObject.transform.position = new Vector2(63.6f,-0.3f);
            gameObject.transform.localScale = new Vector3(1, 1, 1); 
        }
        if(threeToFour) gameObject.transform.localScale = new Vector3(1, 1, 1); 
        if(threeToEight) gameObject.transform.localScale = new Vector3(1, 1, 1); 
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "threescene" && m_scene.name == "oneScene"){
            SceneManager.LoadScene("threeandfiveScene");
            PlayerPrefs.SetString("Milestone", "threeandfiveScene");
            oneToThree = true;
            threeToOne = false;
        }
        if (other.gameObject.tag == "threescene" && m_scene.name == "fourScene"){
            SceneManager.LoadScene("threeandfiveScene");
            PlayerPrefs.SetString("Milestone", "threeandfiveScene");
            fourToThree = true;
            threeToFour = false;
        }
        if (other.gameObject.tag == "threescene" && m_scene.name == "eightScene"){
            SceneManager.LoadScene("threeandfiveScene");
            PlayerPrefs.SetString("Milestone", "threeandfiveScene");
            eightToThree = true;
            threeToEight = false;
        }
        if (other.gameObject.tag == "onescene"){
            SceneManager.LoadScene("oneScene");
            PlayerPrefs.SetString("Milestone", "oneScene");
            threeToOne = true;
            oneToThree = false;
            fourToThree = false;
            eightToThree = false;
        }
        if (other.gameObject.tag == "fourscene"){
            SceneManager.LoadScene("fourScene");
            PlayerPrefs.SetString("Milestone", "fourScene");
            threeToFour = true;
            oneToThree = false;
            fourToThree = false;
            eightToThree = false;
        }
        if (other.gameObject.tag == "eightscene"){
            SceneManager.LoadScene("eightScene");
            PlayerPrefs.SetString("Milestone", "eightScene");
            threeToEight = true;
            oneToThree = false;
            fourToThree = false;
            eightToThree = false;
        }
        
    }
}
