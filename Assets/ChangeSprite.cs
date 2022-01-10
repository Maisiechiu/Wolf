using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    private Sprite WolfFlower, RedhatFlower;
    private Sprite WolfNormal, RedhatNormal;


    public GameObject wolf;
    public GameObject redhat;

    private SpriteRenderer _spriteRendererW;
    private SpriteRenderer _spriteRendererR;
    
    // Start is called before the first frame update
    void Start()
    {
        //wolf = GameObject.Find("Player Variant");
        //redhat = GameObject.Find("Aliveredhat");
        WolfFlower = Resources.Load<Sprite>("flower_wolf");
        RedhatFlower = Resources.Load<Sprite>("flower_redhat");
        WolfNormal = Resources.Load<Sprite>("Jump-1");
        RedhatNormal = Resources.Load<Sprite>("16");

        _spriteRendererW = wolf.GetComponent<SpriteRenderer>();
        _spriteRendererR = redhat.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeToFlowerR()
    {
        Debug.Log("change sprite");
        //redhat.gameObject.GetComponent<SpriteRenderer>().sprite = RedhatFlower;
        _spriteRendererR.sprite = RedhatFlower;
    }
    public void ChangeToNormalR()
    {
        //redhat.gameObject.GetComponent<SpriteRenderer>().sprite = RedhatNormal;
        _spriteRendererR.sprite = RedhatNormal;
    }
    public void ChangeToFlowerW()
    {
        //wolf.gameObject.GetComponent<SpriteRenderer>().sprite = WolfFlower;
        _spriteRendererW.sprite = WolfFlower;
    }
    public void ChangeToNormalW()
    {
        //wolf.gameObject.GetComponent<SpriteRenderer>().sprite = WolfNormal;
        _spriteRendererW.sprite = WolfNormal;
    }
}
