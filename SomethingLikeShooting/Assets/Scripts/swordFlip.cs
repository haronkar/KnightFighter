using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordFlip : MonoBehaviour
{
    private bool m_FacingRight = true;
    private Transform player;

    private Vector2 mouse;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        mouse = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
        var playerScreenPoint = Camera.main.WorldToScreenPoint(player.transform.position);

        if (mouse.x < playerScreenPoint.x  && m_FacingRight)
        {
            Flip();
        }

        if (mouse.x > playerScreenPoint.x && !m_FacingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.y *= -1;
        transform.localScale = theScale;
    }
}
