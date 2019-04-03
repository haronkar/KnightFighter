using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class manager : MonoBehaviour
{
    public Animator animator;
    void Update()
    {
        if (Input.GetKeyDown("return") || Input.GetKeyDown("enter"))
            animator.SetTrigger("Fade");
    }
}
