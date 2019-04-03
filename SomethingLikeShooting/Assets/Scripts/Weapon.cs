using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private float timeBtwShots;
    public float starrtTimeBtwShots;

    public GameObject[] bullet;
    public Transform[] shotPoint;


    void Update()
    {
        if (timeBtwShots <= 0)
        {
            if (Input.GetButton("Fire1"))
            {
                for(int i = 0; i <= shotPoint.Length - 1; i++)
                {
                    for (int j = 0; j <= bullet.Length - 1; j++)
                    {
                        int randB = Random.Range(0, bullet.Length);
                        GameObject goli = Instantiate(bullet[randB], shotPoint[i].position, transform.rotation);
                        break;
                    }
                }
                timeBtwShots = starrtTimeBtwShots;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
