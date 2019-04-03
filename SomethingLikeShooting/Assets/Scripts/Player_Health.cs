using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour
{
    public float startHealth;
    public float health;

    public Image healthBar;

    private void Start()
    {
        health = startHealth;
    }
    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        healthBar.fillAmount = health / startHealth;
    }
}
