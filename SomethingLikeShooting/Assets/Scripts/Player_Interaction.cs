using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interaction : MonoBehaviour
{
    private Animator anim;
    private bool inRange;
    private bool isSelected;

    public GameObject[] items;
    public GameObject spawnPoint;
    public Vector3 offset;

    public static int selectedWeapon;

    private void Start()
    {
        anim = GetComponent<Animator>();

        isSelected = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inRange && isSelected && Player_Stats.Points >= 1500)
        {
            anim.SetBool("opened", true);
            selectedWeapon = Random.Range(0, items.Length);
            Debug.Log(selectedWeapon);
            Player_Stats.Points -= 1500;
            isSelected = false;
            //OpenChest();
        }
    }

    public void OpenChest()
    {
        GameObject weapon = Instantiate(items[selectedWeapon], spawnPoint.transform.position + offset, Quaternion.identity);
        weapon.transform.parent = spawnPoint.transform;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        inRange = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        inRange = false;
    }

    public void Remove()
    {
        Destroy(spawnPoint);
    }
}
