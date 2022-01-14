using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Threeandfivedoor : MonoBehaviour
{
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {


        _animator = gameObject.GetComponent<Animator>();
        if (PlayerController.door35hasopen)
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
