using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onedoor : MonoBehaviour
{

    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {


        _animator = gameObject.GetComponent<Animator>();
        if (PlayerController.dooronehasopen)
        {

            _animator.SetBool("doorhasopen", true);
        }



    }

    // Update is called once per frame
    void Update()
    {

    }
    public void opendoor()
    {
        _animator.SetTrigger("opendoor");
        _animator.SetBool("doorhasopen", true);
    }
}
