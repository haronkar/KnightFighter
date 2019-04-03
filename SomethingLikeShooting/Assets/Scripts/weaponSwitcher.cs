using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponSwitcher : MonoBehaviour
{
    void Start()
    {
        SelectWeapon(0);
    }

    public void SelectWeapon(int item)
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == item)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
