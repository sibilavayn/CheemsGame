using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Character : Unit
{
    [SerializeField]
    private int lives=5;

    public int Lives
    {
        get {return lives;}
        set
        {
            if (value <5) lives=value;
            livesBar.Refresh();
        }
    }

    private LivesBar livesBar;
    [SerializeField]
    private float speed=3.0f;

    [SerializeField]
    private float jumpForce=10.0f;
    private bool isGrounded=false;

    new private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer sprite;

    private void Awake ()
    {
        livesBar=FindObjectOfType<LivesBar>();
        rigidbody=GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
        sprite=GetComponentInChildren <SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        CheckGround ();
    }

    private void Update ()
    {
        if (Input.GetButton("Horizontal")) Run ();
        if (isGrounded && Input.GetButtonDown("Jump")) Jump();

    }

    private void Run ()
    {
        Vector3 direction =transform.right*Input.GetAxis("Horizontal");
        transform.position=Vector3.MoveTowards(transform.position, transform.position+direction, speed*Time.deltaTime);

        sprite.flipX=direction.x<0.0f;
    }

    private void Jump ()
    {
        rigidbody.AddForce(transform.up*jumpForce, ForceMode2D.Impulse);
    }

     public override void ReceiveDamage()
    {
        Lives--;

        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(transform.up * 8.0F, ForceMode2D.Impulse);
        if(Lives == 0) 
        {
            Die();
            SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
        }
     
    }
    void OnTriggerEnter2D (Collider2D other)
     {
         if (other.gameObject.tag == "Enemy") 
         {
             ReceiveDamage();
         }
     }
     
    private void CheckGround ()
    {
        Collider2D[] colliders=Physics2D.OverlapCircleAll(transform.position, 1.0f);
        isGrounded=colliders.Length >1;
    }

    private void Puk(){
        //TODO: puk
    }
    
}
