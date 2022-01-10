using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class oldman : MonoBehaviour
{
    public NPCConversation myConversation;
    public Sprite RedhatFlower;
    private SpriteRenderer _spriteRendererR;
    public GameObject redhat;

    /*void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ConversationManager.Instance.StartConversation(myConversation);
        }
    }*/
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha2))
        {
            ConversationManager.Instance.StartConversation(myConversation);
        }
    }
}
