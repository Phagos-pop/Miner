using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffects : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Hero>())
        {
            collision.gameObject.GetComponent<Hero>().Destroy();
        }
        if (collision.gameObject.GetComponent<Enemy>())
        {
            Destroy(collision.gameObject.GetComponent<Enemy>().gameObject);
        }
    }
}
