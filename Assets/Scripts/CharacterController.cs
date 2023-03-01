using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    float horizontalMovement;

    public float fuerzaSalto;
    public GameManager gameManager;

    private Rigidbody2D rigidbody2D;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");

        if (horizontalMovement < 0.0f)
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (horizontalMovement > 0.0f)
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("estaSaltando", true);
            rigidbody2D.AddForce(new Vector2(0, fuerzaSalto));
        }
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(horizontalMovement, rigidbody2D.velocity.y);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            animator.SetBool("estaSaltando", false);
        }

        if (collision.gameObject.tag == "Obstaculo")
        {
            gameManager.gameOver = true;
        }
    }
}
