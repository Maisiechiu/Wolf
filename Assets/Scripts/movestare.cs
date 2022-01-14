using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movestare : MonoBehaviour
{

    private Transform _transform;
    private Rigidbody2D _rb;
    public AudioSource _audiosource;
    public AudioClip _movestaresound;

    private bool _move;

    private bool _movedown;
    private bool _moveup;
    // Start is called before the first frame update
    void Start()
    {
        _transform = gameObject.GetComponent<Transform>();
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _move = false;
        _movedown = false;
        _moveup = false;


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string layerName = LayerMask.LayerToName(collision.collider.gameObject.layer);


        if (layerName == "Player")
        {
            _move = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_move)
        {
            if (_transform.position.y > 15.0f && !_movedown)
            {
                _moveup = false;
                _movedown = true;
                StartCoroutine(WaitMovedoewn());

            }
            if (_transform.position.y < -5.1f && !_moveup)
            {
                _moveup = true;
                _movedown = false;
                StartCoroutine(WaitMoveup());

            }


        }

    }
    public IEnumerator WaitMoveup()
    {
        _rb.velocity = new Vector2(0.0f, 0.0f);
        _audiosource.Stop();
        yield return new WaitForSeconds(0.7f);
        _audiosource.PlayOneShot(_movestaresound);
        _rb.velocity = new Vector2(0.0f, 3.0f);




    }
    public IEnumerator WaitMovedoewn()
    {
        _rb.velocity = new Vector2(0.0f, 0.0f);
        _audiosource.Stop();
        yield return new WaitForSeconds(0.7f);
        _audiosource.PlayOneShot(_movestaresound);
        _rb.velocity = new Vector2(0.0f, -3.0f);

    }
}
