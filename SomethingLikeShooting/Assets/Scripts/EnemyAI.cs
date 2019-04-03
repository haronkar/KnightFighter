using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    public float speed = 5f;
    private bool m_FacingRight = true;

    private Renderer rend;
    private Animator anim;

    private Transform player;
    private Transform campFire;
    private Rigidbody2D rb;

    public GameObject firePartical;

    void Start()
    {
        rend = GetComponent<Renderer>();
        anim = GetComponent<Animator>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        campFire = GameObject.FindGameObjectWithTag("Campfire").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }
   
    void FixedUpdate()
    {
        if(player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

            if (player.position.x > transform.position.x && !m_FacingRight)
            {
                Flip();
            }
            else if (player.position.x < transform.position.x && m_FacingRight)
            {
                Flip();
            }
        }
    }

    void Flip()
    {
        m_FacingRight = !m_FacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private IEnumerator EnemyBurn()
    {
        Physics2D.IgnoreCollision(campFire.GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
        GameObject go = Instantiate(firePartical, transform.position, Quaternion.identity);
        go.transform.parent = transform;
        rend.material.color = Color.gray;

        yield return new WaitForSeconds(3.5f);

        anim.SetTrigger("Die");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Campfire"))
        {
            Debug.Log(collision.gameObject.tag);
            StartCoroutine("EnemyBurn");
        }
    }

    

}