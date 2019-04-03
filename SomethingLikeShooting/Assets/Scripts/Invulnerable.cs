using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invulnerable : MonoBehaviour
{
    private Renderer rend;
    private Color color;
    private bool invincible = false;
    public int damage;

    void Start()
    {
        rend = GetComponent<Renderer>();
        color = rend.material.color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!invincible)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("Hit");
                Destroy(collision.gameObject);
                WaveSpawner.enemieskilled++;
                WaveSpawner.enemiesAlive--;
                StartCoroutine("GetInvulnerable");
            }
        }
    }

    private IEnumerator GetInvulnerable()
    {
        Physics2D.IgnoreLayerCollision(8, 10, true);
        color.a = 0.5f;
        rend.material.color = color;
        GetComponent<Player_Stats>().TakeDamage(damage);
        invincible = true;

        yield return new WaitForSeconds(3f);

        invincible = false;
        Physics2D.IgnoreLayerCollision(8, 10, false);
        color.a = 1f;
        rend.material.color = color;
    }
}
