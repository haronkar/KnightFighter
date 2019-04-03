using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawn : MonoBehaviour
{
    public GameObject[] weapons;

    public void Spawn()
    {
        Instantiate(weapons[0], transform.position, Quaternion.identity);
    }
}
