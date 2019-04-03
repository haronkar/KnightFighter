using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ainmtrigger : MonoBehaviour
{
    public Animator anim;

    public void Trigger()
    {
        anim.SetTrigger("trigger");
    }
}
