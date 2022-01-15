using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliveController : MonoBehaviour
{
    public GameObject _aliveeffect;
    public GameObject _light;

    public ParticleSystem _alivepartical;
    public float destroyDelay;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private Vector3 _wolfpos;

    public float _movingSpeed;

    private Vector3 _effectpos;

    private Vector3 _direction;

    private float _distance;

    private float _movedis;

    public float xdec_speed;
    public float ydec_speed;

    private float x_dec;
    private float y_dec;
    private Rigidbody2D _rigidbody;


    public AudioSource _audiosource;

    public AudioClip _alivebefore;

    public AudioClip _aliveafter;
    public float jumpSpeed;






    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _animator = gameObject.GetComponent<Animator>();
        _audiosource.PlayOneShot(_alivebefore);
        _aliveeffect.SetActive(true);
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();

        _alivepartical = _aliveeffect.GetComponent<ParticleSystem>();
        StartCoroutine(fadeCoroutine());

        _effectpos = _aliveeffect.GetComponent<Transform>().position;

        _wolfpos = gameObject.GetComponent<Transform>().position;

        _direction = (_effectpos - _wolfpos).normalized;

        _distance = (_effectpos - _wolfpos).magnitude;

        _movedis = 0;

        x_dec = 0;
        y_dec = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("press up arrow");
            Vector2 newVelocity;
            newVelocity.x = _rigidbody.velocity.x;
            newVelocity.y = jumpSpeed;

            _rigidbody.velocity = newVelocity;
            _light.SetActive(true);

        }

    }

    void FixedUpdate()
    {
        if (_movedis < _distance)
        {
            _movedis += (_direction * (_movingSpeed * Time.deltaTime)).magnitude;
            _aliveeffect.GetComponent<Transform>().position -= _direction * (_movingSpeed * Time.deltaTime);


        }

        if (x_dec < 30)
        {
            x_dec += (new Vector3(1, 0, 0) * (xdec_speed * Time.deltaTime)).magnitude;
            var Shape = _alivepartical.shape;
            Shape.enabled = true;
            Shape.scale -= new Vector3(1, 0, 0) * (xdec_speed * Time.deltaTime);
        }

        if (y_dec < 15)
        {
            y_dec += (new Vector3(0, 1, 0) * (ydec_speed * Time.deltaTime)).magnitude;
            var Shape = _alivepartical.shape;
            Shape.enabled = true;
            Shape.scale -= new Vector3(0, 1, 0) * (ydec_speed * Time.deltaTime); ;
        }

    }
    private IEnumerator fadeCoroutine()
    {
        yield return new WaitForSeconds(8f);
        _audiosource.PlayOneShot(_aliveafter);

        _animator.SetTrigger("alive");

        while (destroyDelay > 0)
        {
            destroyDelay -= Time.deltaTime;

            Color newColor = _spriteRenderer.color;
            newColor.a += Time.deltaTime / destroyDelay;
            _spriteRenderer.color = newColor;
            yield return null;
        }


    }
}
