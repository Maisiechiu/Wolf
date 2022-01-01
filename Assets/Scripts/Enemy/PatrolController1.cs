using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolController1 : EnemyController
{
    public float walkSpeed;
    public float edgeSafeDistance;
    public float behaveIntervalLeast;
    public float behaveIntervalMost;



    private int _reachEdge;
    private bool _isChasing;
    private bool _isMovable;


    public Color[] invulnerableColor;

    public GameObject ShockCollider;
    public GameObject Shock1;
    public GameObject Shock2;
    public GameObject ShockEffect;
    public GameObject hurteffect;
    public GameObject _dieeffect;

    private GameObject _hurteffect;

    private Transform _playerTransform;
    private Transform _transform;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    public AudioSource _audiosource;
    public AudioClip _attacksound;
    public AudioClip _hurtaudio;
    public AudioClip _dieaudio;

    // Start is called before the first frame update
    void Start()
    {
        ShockEffect.GetComponent<ParticleSystem>().Pause();
        _playerTransform = GlobalController.Instance.player.GetComponent<Transform>();
        _transform = gameObject.GetComponent<Transform>();
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        _animator = gameObject.GetComponent<Animator>();
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        _currentState = new Patrol();

        _isChasing = false;
        _isMovable = true;
    }

    // Update is called once per frame
    void Update()
    {
        // update distance between player and enemy
        _playerEnemyDistance = _playerTransform.position.x - _transform.position.x;

        // update edge detection
        Vector2 detectOffset;
        detectOffset.x = edgeSafeDistance * _transform.localScale.x;
        detectOffset.y = 0;
        _reachEdge = checkGrounded(detectOffset) ? 0 : (_transform.localScale.x > 0 ? 1 : -1);

        // update state
        if (!_currentState.checkValid(this))
        {
            if (_isChasing)
            {
                _currentState = new Patrol();
            }
            else
            {
                _currentState = new Chase();
            }

            _isChasing = !_isChasing;
        }

        if (_isMovable)
            _currentState.Execute(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string layerName = LayerMask.LayerToName(collision.collider.gameObject.layer);

        if (layerName == "Player")
        {
            PlayerController playerController = collision.collider.GetComponent<PlayerController>();
            playerController.hurt(1);
        }
    }

    public override float behaveInterval()
    {
        return UnityEngine.Random.Range(behaveIntervalLeast, behaveIntervalMost);
    }

    public int reachEdge()
    {
        Debug.Log(_reachEdge);
        return _reachEdge;

    }

    public override void hurt(int damage)
    {
        health = Math.Max(health - damage, 0);

        _isMovable = false;

        _audiosource.PlayOneShot(_hurtaudio);

        if (health == 0)
        {
            die();
            return;
        }

        Vector2 newVelocity = hurtRecoil;
        newVelocity.x *= _transform.localScale.x;

        _rigidbody.velocity = newVelocity;

        StartCoroutine(hurtCoroutine());
    }

    private IEnumerator hurtCoroutine()
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

        yield return new WaitForSeconds(hurtRecoilTime);
        _isMovable = true;
    }

    private bool checkGrounded(Vector2 offset)
    {
        Vector2 origin = _transform.position;
        origin += offset;

        float radius = 5f;

        // detect downwards
        Vector2 direction;
        direction.x = 0;
        direction.y = -1;

        float distance = 1.1f;
        LayerMask layerMask = LayerMask.GetMask("Platform");

        RaycastHit2D hitRec = Physics2D.CircleCast(origin, radius, direction, distance, layerMask);
        return hitRec.collider != null;
    }

    public void walk(float move)
    {
        int direction = move > 0 ? 1 : move < 0 ? -1 : 0;

        float newWalkSpeed = (direction == _reachEdge) ? 0 : direction * walkSpeed;
        // Debug.Log(newWalkSpeed);
        // flip sprite
        if (direction != 0 && health > 0)
        {
            Vector3 newScale = _transform.localScale;
            newScale.x = direction;
            _transform.localScale = newScale;
        }

        // set velocity
        Vector2 newVelocity = _rigidbody.velocity;
        newVelocity.x = newWalkSpeed;
        _rigidbody.velocity = newVelocity;

        // animation
        _animator.SetFloat("Speed", Math.Abs(newWalkSpeed));
    }

    protected override void die()
    {
        _animator.SetTrigger("isDead");

        _isChasing = false;
        _isMovable = false;

        Instantiate(_dieeffect, transform.position + new Vector3(-1 * transform.localScale.x, 0, 0), Quaternion.identity);
        _audiosource.PlayOneShot(_dieaudio);


        Vector2 newVelocity;
        newVelocity.x = 0;
        newVelocity.y = 0;
        _rigidbody.velocity = newVelocity;

        gameObject.layer = LayerMask.NameToLayer("Decoration");

        Vector2 newForce;
        newForce.x = _transform.localScale.x * deathForce.x;
        newForce.y = deathForce.y;
        _rigidbody.AddForce(newForce, ForceMode2D.Impulse);

        StartCoroutine(fadeCoroutine());
    }

    private IEnumerator fadeCoroutine()
    {
        Vector3 position = new Vector3(-1.5f * _playerTransform.localScale.x, 1, 0);
        position += _playerTransform.position;
        _hurteffect = Instantiate(hurteffect, position, Quaternion.identity);


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
        Destroy(_hurteffect);
        Destroy(gameObject);
    }

    public void attack()
    {
        _animator.SetTrigger("attack");

        StartCoroutine(playanddestroyCoroutine());

    }

    private IEnumerator playanddestroyCoroutine()
    {
        yield return new WaitForSeconds(0.6f);

        ShockEffect.GetComponent<ParticleSystem>().Play();
        _audiosource.PlayOneShot(_attacksound);
        Shock1 = Instantiate(ShockCollider, _transform);
        Shock2 = Instantiate(ShockCollider, _transform);
        Shock1.GetComponent<Rigidbody2D>().simulated = true;
        Shock2.GetComponent<Rigidbody2D>().simulated = true;
        Shock1.GetComponent<Rigidbody2D>().AddForce(new Vector3(0.08f, 0, 0));
        Shock2.GetComponent<Rigidbody2D>().AddForce(new Vector3(-0.08f, 0, 0));

        yield return new WaitForSeconds(0.8f);
        Destroy(Shock1);
        Destroy(Shock2);


    }


    public abstract class PatrolState
    {
        public abstract bool checkValid(PatrolController1 enemyController);
        public abstract void Execute(PatrolController1 enemyController);
    }

    public class Patrol : State
    {
        private PatrolState _currentState;
        // private int _currentStateCase = 0;
        private bool _isFinished;   // ready for next state

        public Patrol()
        {
            _currentState = new Idle();
            _isFinished = true;

        }

        public override bool checkValid(EnemyController enemyController)
        {
            float playerEnemyDistanceAbs = Math.Abs(enemyController.playerEnemyDistance());
            return playerEnemyDistanceAbs > 20.0f;
        }

        public override void Execute(EnemyController enemyController)
        {
            PatrolController1 patrolController = (PatrolController1)enemyController;
            if (!_currentState.checkValid(patrolController) || _isFinished)
            {
                // randomly change current state
                // int randomStateCase;
                // do
                // {
                //     randomStateCase = UnityEngine.Random.Range(0, 1);
                // } while (randomStateCase == _currentStateCase);

                // _currentStateCase = randomStateCase;
                // switch (_currentStateCase)
                // {
                //     case 0:
                //         _currentState = new Idle();
                //         break;
                //     case 1:
                //         _currentState = new WalkingLeft();
                //         break;
                //     case 2:
                //         _currentState = new WalkingRight();
                //         break;
                // }
                _currentState = new Idle();
                patrolController.StartCoroutine(executeCoroutine(patrolController.behaveInterval()));
            }

            _currentState.Execute(patrolController);
        }

        private IEnumerator executeCoroutine(float delay)
        {
            _isFinished = false;
            yield return new WaitForSeconds(delay);
            if (!_isFinished)
                _isFinished = true;
        }
    }

    public class Chase : State
    {
        private bool _isWalk;

        public Chase()
        {
            _isWalk = true;

        }



        public override bool checkValid(EnemyController enemyController)
        {
            float playerEnemyDistanceAbs = Math.Abs(enemyController.playerEnemyDistance());
            return playerEnemyDistanceAbs <= 30.0f;
        }

        public override void Execute(EnemyController enemyController)
        {
            if (_isWalk)
            {

                PatrolController1 patrolController = (PatrolController1)enemyController;
                float dist = patrolController.playerEnemyDistance();
                patrolController.walk(Math.Abs(dist) < 0.1f ? 0 : dist);

                if (Time.fixedTime % 3 == 0)
                {

                    patrolController.attack();
                    patrolController.StartCoroutine(this.attackCoroutine());
                }

            }


        }
        private IEnumerator attackCoroutine()
        {
            _isWalk = false;
            yield return new WaitForSeconds(1.0f);
            _isWalk = true;

        }
    }

    public class Idle : PatrolState
    {
        public override bool checkValid(PatrolController1 patrolController)
        {
            return patrolController.reachEdge() == 0;
        }

        public override void Execute(PatrolController1 patrolController)
        {
            patrolController.walk(0);
        }
    }
    public class WalkingLeft : PatrolState
    {
        public override bool checkValid(PatrolController1 patrolController)
        {
            return patrolController.reachEdge() != -1;
        }

        public override void Execute(PatrolController1 patrolController)
        {
            patrolController.walk(-1);
        }
    }

    public class WalkingRight : PatrolState
    {
        public override bool checkValid(PatrolController1 patrolController)
        {
            return patrolController.reachEdge() != 1;
        }

        public override void Execute(PatrolController1 patrolController)
        {
            patrolController.walk(1);
        }
    }
}
