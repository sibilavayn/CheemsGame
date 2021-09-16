using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{

protected virtual void Awake() { }
protected virtual void Start() { }
      public float speed;
      public int lives=4;
      public float distance;
      private bool movingRight=true;
      public Transform groundDetection;
    
   public Collider coll;
   void Update ()
   {
       transform.Translate(Vector2.right*speed*Time.deltaTime);
       RaycastHit2D groundInfo=Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
       if (groundInfo.collider==false)
         {
           if (movingRight==true)
            {
               transform.eulerAngles=new Vector3(0, -180,0);
               movingRight=false;
            }
               else
            {
               transform.eulerAngles=new Vector3(0,0,0);
               movingRight=true;
            }
         }
   }
         public override void ReceiveDamage()
         {
            lives--;
            if(lives == 0) 
            {
            Die();
            }
         }

         void OnTriggerEnter2D (Collider2D other)
         {
            if (other.gameObject.tag == "Weapon") 
            {
               ReceiveDamage();
            }
         }
}
