using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public int damage;
    public Rigidbody2D rb;
    public float distance;
    public LayerMask whatIsSolid;
    public GameObject effect;


    void Start ()
    {
        rb.velocity = transform.right * speed;
        Invoke("DestroyBullet", lifeTime);
    }

    void Update ()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<EnemyHealth>().TakeDamage(damage);
            }
            DestroyBullet ();

        }


    }
    void DestroyBullet ()
    {
        Instantiate(effect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

}
