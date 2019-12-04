using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //private Animator animator;
    private SpriteRenderer sp;
    private Rigidbody2D rb;
    public float speed = 15.0f;
    public float fuerzaSalto = 200.0f;
    private Collider2D col;

    // Use this for initialization
    void Start()
    {
        //animator = this.GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");
        
        if (horizontal > 0)
        {
            //animator.SetInteger("Direction", 6);
            sp.flipX = false;
        }
        else if (horizontal < 0)
        {
            //animator.SetInteger("Direction", 4);
            sp.flipX = true;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        if (isGrounded())
            rb.AddForce(move * speed);



        // Control del salto.
        if ((Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded())
        {
            //horizontal = 1;
            Vector3 vSalto = new Vector3(0, 1, 0);
            rb.AddForce(vSalto * fuerzaSalto);
        }


    }

    private bool isGrounded()
    {
        float distToGround = col.bounds.extents.y;
        //Debug.Log("Distancia al suelo: " + distToGround);
        Debug.Log("Esta en suelo?: " + Physics2D.Raycast(transform.position, -Vector2.up, distToGround + 0.5f).collider);
        return Physics2D.Raycast(transform.position, -Vector2.up, distToGround + 0.5f);
        //var hit: RaycastHit2D = Physics2D.Raycast(transform.position, -Vector2.up, 0.1);
    }
}