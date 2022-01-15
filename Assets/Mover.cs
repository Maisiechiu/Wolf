using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed = 1f;
    private Vector3 _targetPosition;
    
    private Animator _animator;
    
    private void Start()
    {
        //_animator = gameObject.GetComponent<Animator>();
        _targetPosition = new Vector3(40.0f, -8.4f, -3.9f);
    }
    
    private void Update()
    {
        if(alive_redhat.start && gameObject.transform.position.x != _targetPosition.x)
        {
            //float moveDirection = transform.position.x - _targetPosition.x;
            gameObject.GetComponent<PlayerController>().enabled = false;
            _animator = gameObject.GetComponent<Animator>();
            Debug.Log("moving");
            /*if (moveDirection < 0)
            {  
                Vector3 newScale;
                newScale.x = moveDirection < 0 ? 1 : -1;
                newScale.y = 1;
                newScale.z = 1;

                transform.localScale = newScale;
                _animator.SetTrigger("IsRotate");
            }
            else if (moveDirection > 0)
            {
                // move forward
                _animator.SetBool("IsRun", true);
            }*/
            //_animator.SetBool("IsRun", true);
        //     transform.position = Vector3.MoveTowards(gameObject.transform.position, _targetPosition, speed * Time.deltaTime);
                transform.position = _targetPosition;
                transform.localScale = new Vector3 (1,1,1);
        }
        if(alive_redhat.start && gameObject.transform.position.x == _targetPosition.x)
        {
            _animator.enabled = false;
        }
        
        
    }
}
