using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    private Animator anim;
    public float startHealth;
    public float health;

    private void Start()
    {
        anim = GetComponent<Animator>();
        health = startHealth;
    }
    private void Update()
    {
        if (health <= 0)
        {
           anim.SetTrigger("Die");
        }

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public void Die()
    {
        Destroy(gameObject);
        WaveSpawner.enemiesAlive--;
        Player_Stats.Points += 100;
        Debug.Log(WaveSpawner.enemiesAlive);
        WaveSpawner.enemieskilled++;
    }
}
