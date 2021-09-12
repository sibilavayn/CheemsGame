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
    

    new private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer sprite;
    public GameObject player;
    public static bool isAttacking=false;
    private AudioSource source;
    

    private void Awake ()
    {
        livesBar=FindObjectOfType<LivesBar>();
        rigidbody=GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
        sprite=GetComponentInChildren <SpriteRenderer>();
        source=GetComponent<AudioSource>();
    }


    private void Update ()
    {
        if (Input.GetButton("Horizontal")) Run ();
        if (Input.GetButtonDown("Jump")) Jump(); //isGr. в начале
        // if (Input.GetKeyDown(KeyCode.A))
        // {
        //     transform.rotation = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);
        // }
        // else if (Input.GetKeyDown(KeyCode.D))
        // {
        //     transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
        // }
    }
    private void Run ()
    {
        Vector3 direction=transform.right*Input.GetAxis("Horizontal");
        transform.position=Vector3.MoveTowards(transform.position, transform.position+direction, speed*Time.deltaTime);
        sprite.flipX=direction.x<0.0f;
        // transform.Rotate(0f, 180f, 0f);
    }

    private void Jump ()
    {
        if (rigidbody.velocity.y!=0)
	    {
		    return;
	    }
	    else
	    {
            rigidbody.AddForce(transform.up*jumpForce, ForceMode2D.Impulse); 
	    }   
        source.Play();
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

}
