using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    public bool inRange;
    private GameObject weapon;
    public GameObject holder;
    private weaponSwitcher ws;
    private bool isSelected;

    private void Start()
    {
        weapon = GameObject.FindWithTag("weapon");
        holder = GameObject.Find("Weapons");
        ws = holder.GetComponent<weaponSwitcher>();

        isSelected = true;
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E) && inRange && isSelected)
        {
            Debug.Log(weapon.name.Substring(0, 5));
            Debug.Log(Player_Interaction.selectedWeapon);
            ws.SelectWeapon(Player_Interaction.selectedWeapon);
            isSelected = false;

            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        inRange = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        inRange = false;
    }
}
