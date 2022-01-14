﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movestare : MonoBehaviour
{

    private Transform _transform;
    private Rigidbody2D _rb;
    public AudioSource _audiosource;
    public AudioClip _movestaresound;

    private bool _move;
    // Start is called before the first frame update
    void Start()
    {
        _transform = gameObject.GetComponent<Transform>();
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _move = false;


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
            if (_transform.position.y > 15.0f)
            {
                _audiosource.Stop();
                _rb.velocity = new Vector2(0.0f, -3.0f);
            }
            if (_transform.position.y < -5.1f)
            {
                _rb.velocity = new Vector2(0.0f, 3.0f);

            }


        }

    }
}
