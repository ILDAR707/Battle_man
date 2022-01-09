using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletContact : MonoBehaviour
{
    public GameObject explosionPrefab;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Enemy"))
            {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            collision.gameObject.GetComponent<Enemy>().EnemyDead();
        }
    }
}