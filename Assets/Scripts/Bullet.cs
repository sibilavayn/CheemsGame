using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed=20.0f;
    public Rigidbody2D rb;
    void Start()
    {
        rb.velocity=transform.right*speed;
        // Destroy(gameObject, 2);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy (gameObject);
        }
        else
        {
            Destroy(gameObject, 2);
        }
       
    }
    
    
}
