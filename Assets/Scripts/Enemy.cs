using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public Vector2 moveVelocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Move());
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
    }

    private IEnumerator Move()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            moveVelocity.x = (Random.Range(-1, 1));
            moveVelocity.y = (Random.Range(-1, 1));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Hero>())
        {
            Destroy(collision.gameObject.GetComponent<Hero>().gameObject);
        }
    }
}
