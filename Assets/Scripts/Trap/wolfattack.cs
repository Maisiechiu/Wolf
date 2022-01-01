using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolfattack : MonoBehaviour
{
    public Vector2 direction;
    public int damageToPlayer;
    public float movingSpeed;
    public float destroyTime;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string layerName = LayerMask.LayerToName(collision.collider.gameObject.layer);

        if (layerName == "Player")
        {
            PlayerController playerController = collision.collider.GetComponent<PlayerController>();
            playerController.hurt(damageToPlayer);
            StartCoroutine(destroyCoroutine(0.01f));
        }
    }


    void FixedUpdate()
    {

        if (movingSpeed != 0 && rb != null)
            rb.position += (direction) * (movingSpeed * Time.deltaTime);
        if (WolfController.isdie)
        {
            Destroy(this.gameObject);
        }
        StartCoroutine(destroyCoroutine(destroyTime));
    }


    private IEnumerator destroyCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(this.gameObject);
    }
}
