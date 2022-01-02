using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class WolfController : MonoBehaviour
{
    public Camera _camera;
    public GameObject _projectile;
    public Color[] invulnerableColor;

    private GameObject _hurteffect;

    public int health;
    private Transform _playerTransform;

    public static bool isdie;

    public AudioSource _audiosource;

    public AudioClip _attacksound;
    public AudioClip _circleshoot;

    public AudioClip _wolfyelling;

    public AudioClip _wolfdie;

    public AudioClip _diebefore;

    public AudioClip _dieafter;

    public GameObject[] projectile;

    public GameObject[] circle_projectile;

    public GameObject hurteffect;

    public GameObject _dieeffect;

    public float destroyDelay;

    public GameObject Alivewolf;




    private Transform _transform;
    private Animator _animator;
    private bool is_changePosition;
    // Start is called before the first frame update

    private int[] attack_pos;
    private float attack_delay;
    private float change_delay;
    private SpriteRenderer _spriteRenderer;
    private int attack_type;
    void Start()
    {
        _playerTransform = GlobalController.Instance.player.GetComponent<Transform>();
        _animator = GetComponent<Animator>();
        _transform = gameObject.GetComponent<Transform>();
        StartCoroutine(change_postition(UnityEngine.Random.Range(1.0f, 3.0f)));
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _dieeffect.GetComponent<ParticleSystem>().Pause();
        isdie = false;


    }

    // Update is called once per frame
    void Update()
    {

    }

    void update_position()
    {

        float x_position = UnityEngine.Random.Range(-20.0f, 20.0f);
        x_position = _playerTransform.position.x + x_position;
        if (x_position < -10)
        {
            x_position = -10;
        }
        else if (x_position > 10)
        {
            x_position = 10;
        }

        transform.position = new Vector3(x_position, transform.position.y, 0);






    }
    // private IEnumerator Startattack(float delay)
    // {

    // }

    private IEnumerator change_postition(float delay)
    {

        if (!isdie)
        {

            _animator.SetTrigger("emerge");
            update_position();

            attack_delay = UnityEngine.Random.Range(1.0f, 2.0f);
            yield return new WaitForSeconds(attack_delay);

            _animator.SetTrigger("attack");
            _audiosource.PlayOneShot(_attacksound);

            yield return new WaitForSeconds(0.5f);
            if (attack() == 3)
            {
                yield return new WaitForSeconds(1.8f);

            }
            yield return new WaitForSeconds(delay);

            StartCoroutine(change_postition(UnityEngine.Random.Range(1.0f, 3.0f)));
        }


    }

    int[] Random_number()
    {
        int[] array = new int[3];
        int[] pos_attack = new int[17];

        for (int i = 0; i < array.Length;)
        {
            bool no_repeat = true;
            int number = UnityEngine.Random.Range(0, 17);
            for (int j = 0; j < i; ++j)
            {
                if (number == array[j])
                {
                    no_repeat = false;
                    break;
                }
            }
            if (no_repeat)
            {
                array[i] = number;
                pos_attack[number] = -9;
                i++;
            }

        }


        for (int i = 0; i < 17; i++)
        {
            if (pos_attack[i] == -9) continue;

            else
            {
                pos_attack[i] = i - 8;
            }
        }


        return pos_attack;

    }
    int attack()
    {
        if (!isdie)
        {
            attack_type = UnityEngine.Random.Range(1, 4);
            if (attack_type == 1)
            {
                attack_pos = Random_number();
                for (int i = 0; i < 17; i++)
                {
                    Instantiate(_projectile, new Vector3(attack_pos[i] * 2, 13f, 0), Quaternion.identity);
                }
            }
            if (attack_type == 2)
            {
                Debug.Log("type2");

                for (int i = -3; i < 3; i++)
                {

                    projectile[i + 3] = Instantiate(_projectile, transform.position, Quaternion.identity);
                    projectile[i + 3].GetComponent<wolfattack>().direction = new Vector2(i, -1);
                }
            }

            if (attack_type == 3)
            {

                StartCoroutine(circleattack());

            }

        }


        return attack_type;
    }

    private IEnumerator circleattack()
    {
        if (!isdie)
        {
            float a = 0.5f;
            float b = Convert.ToSingle(Math.Pow(3, 0.5)) / 2.0f;
            Debug.Log(b);

            float res = 3.0f;
            float second = 0.08f;

            //0 30 60 90 120 150 180 210 240 270 300 360


            //象限1
            circle_projectile[0] = Instantiate(_projectile, transform.position, Quaternion.identity);
            circle_projectile[0].GetComponent<wolfattack>().direction = new Vector2(1 * res, 0);
            _audiosource.PlayOneShot(_circleshoot);
            yield return new WaitForSeconds(second);


            circle_projectile[1] = Instantiate(_projectile, transform.position, Quaternion.identity);
            circle_projectile[1].GetComponent<wolfattack>().direction = new Vector2(b * res, a * res);
            _audiosource.PlayOneShot(_circleshoot);
            yield return new WaitForSeconds(second);

            circle_projectile[2] = Instantiate(_projectile, transform.position, Quaternion.identity);
            circle_projectile[2].GetComponent<wolfattack>().direction = new Vector2(a * res, b * res);
            _audiosource.PlayOneShot(_circleshoot);
            yield return new WaitForSeconds(second);

            //象限2           
            circle_projectile[3] = Instantiate(_projectile, transform.position, Quaternion.identity);
            circle_projectile[3].GetComponent<wolfattack>().direction = new Vector2(0 * res, 1 * res);
            _audiosource.PlayOneShot(_circleshoot);
            yield return new WaitForSeconds(second);

            circle_projectile[4] = Instantiate(_projectile, transform.position, Quaternion.identity);
            circle_projectile[4].GetComponent<wolfattack>().direction = new Vector2(-a * res, b * res);
            _audiosource.PlayOneShot(_circleshoot);
            yield return new WaitForSeconds(second);


            circle_projectile[9] = Instantiate(_projectile, transform.position, Quaternion.identity);
            circle_projectile[9].GetComponent<wolfattack>().direction = new Vector2(-b * res, a * res);
            _audiosource.PlayOneShot(_circleshoot);
            yield return new WaitForSeconds(second);

            //象限3
            circle_projectile[5] = Instantiate(_projectile, transform.position, Quaternion.identity);
            circle_projectile[5].GetComponent<wolfattack>().direction = new Vector2(-1 * res, 0);
            _audiosource.PlayOneShot(_circleshoot);
            yield return new WaitForSeconds(second);


            circle_projectile[6] = Instantiate(_projectile, transform.position, Quaternion.identity);
            circle_projectile[6].GetComponent<wolfattack>().direction = new Vector2(-b * res, -a * res);
            _audiosource.PlayOneShot(_circleshoot);
            yield return new WaitForSeconds(second);


            circle_projectile[7] = Instantiate(_projectile, transform.position, Quaternion.identity);
            circle_projectile[7].GetComponent<wolfattack>().direction = new Vector2(-a * res, -b * res);
            _audiosource.PlayOneShot(_circleshoot);
            yield return new WaitForSeconds(second);

            //象限4
            circle_projectile[8] = Instantiate(_projectile, transform.position, Quaternion.identity);
            circle_projectile[8].GetComponent<wolfattack>().direction = new Vector2(0 * res, -1 * res);
            _audiosource.PlayOneShot(_circleshoot);
            yield return new WaitForSeconds(second);

            circle_projectile[10] = Instantiate(_projectile, transform.position, Quaternion.identity);
            circle_projectile[10].GetComponent<wolfattack>().direction = new Vector2(a * res, -b * res);
            _audiosource.PlayOneShot(_circleshoot);
            yield return new WaitForSeconds(second);

            circle_projectile[11] = Instantiate(_projectile, transform.position, Quaternion.identity);
            circle_projectile[11].GetComponent<wolfattack>().direction = new Vector2(b * res, -a * res);
            _audiosource.PlayOneShot(_circleshoot);
            yield return new WaitForSeconds(second);

            circle_projectile[12] = Instantiate(_projectile, transform.position, Quaternion.identity);
            circle_projectile[12].GetComponent<wolfattack>().direction = new Vector2(1 * res, 0 * res);
            _audiosource.PlayOneShot(_circleshoot);
            yield return new WaitForSeconds(second);

        }



    }
    private IEnumerator hurt_recover()
    {

        Vector3 position = new Vector3(-1.5f * _playerTransform.localScale.x, 1, 0);
        position += _playerTransform.position;


        _hurteffect = Instantiate(hurteffect, position, Quaternion.identity);
        _spriteRenderer.color = invulnerableColor[0];
        yield return new WaitForSeconds(0.1f);
        _spriteRenderer.color = invulnerableColor[1];
        yield return new WaitForSeconds(0.1f);
        _spriteRenderer.color = invulnerableColor[0];
        yield return new WaitForSeconds(0.1f);
        _spriteRenderer.color = invulnerableColor[1];
        yield return new WaitForSeconds(0.1f);
        _spriteRenderer.color = invulnerableColor[0];
        yield return new WaitForSeconds(0.1f);
        _spriteRenderer.color = invulnerableColor[1];
        yield return new WaitForSeconds(0.1f);


        Destroy(_hurteffect);
        _spriteRenderer.color = Color.white;



    }


    public void hurt(int damage)
    {
        _audiosource.PlayOneShot(_wolfyelling);
        health = Math.Max(health - damage, 0);


        if (health == 0)
        {
            _audiosource.Stop();
            _animator.SetTrigger("die");
            isdie = true;

            StartCoroutine(die());

        }

        StartCoroutine(hurt_recover());




    }

    private IEnumerator die()
    {

        Vector3 position = new Vector3(-1.5f * _playerTransform.localScale.x, 1, 0);
        position += _playerTransform.position;
        _hurteffect = Instantiate(hurteffect, position, Quaternion.identity);
        _spriteRenderer.color = invulnerableColor[0];
        yield return new WaitForSeconds(1.5f);
        _spriteRenderer.color = invulnerableColor[1];
        yield return new WaitForSeconds(0.1f);
        _spriteRenderer.color = invulnerableColor[0];


        Destroy(_hurteffect);
        _audiosource.PlayOneShot(_wolfdie);
        _camera.GetComponent<ShakeCamera>().isshakeCamera = true;
        yield return new WaitForSeconds(1.0f);
        _audiosource.PlayOneShot(_diebefore);
        _dieeffect.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(1.0f);
        _camera.GetComponent<ShakeCamera>().isshakeCamera = false;
        _audiosource.PlayOneShot(_dieafter);
        StartCoroutine(fadeCoroutine());
        // yield return new WaitForSeconds(5.0f);
        // Destroy(gameObject);
        Alivewolf.SetActive(true);
    }

    private IEnumerator fadeCoroutine()
    {
        while (destroyDelay > 0)
        {
            destroyDelay -= Time.deltaTime;

            if (_spriteRenderer.color.a > 0)
            {
                Color newColor = _spriteRenderer.color;
                newColor.a -= Time.deltaTime / destroyDelay;
                _spriteRenderer.color = newColor;
                yield return null;
            }
        }
    }

}
