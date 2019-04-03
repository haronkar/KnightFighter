using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Stats : MonoBehaviour
{
    public static int Points;
    public int startPoints = 0;

    public float startHealth;
    public static float health;


    private void Start()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        Points = startPoints;
        health = startHealth;
    }

    private void Update()
    {
        if (health <= 0)
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
