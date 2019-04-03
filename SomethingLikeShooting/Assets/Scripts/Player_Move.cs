using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    public float startSpeed;
    public float speed;
    private bool m_FacingRight = true;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    public Animator anim;

    private void Start()
    {
        speed = startSpeed;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"),0.0f);

        moveInput.Normalize();

        anim.SetFloat("Magnitude", moveInput.magnitude);

        transform.position = transform.position + moveInput * speed * Time.deltaTime;

        if (moveInput.x > 0 && !m_FacingRight)
        {
            Flip();
        }
        else if (moveInput.x < 0 && m_FacingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        m_FacingRight = !m_FacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
   
}
