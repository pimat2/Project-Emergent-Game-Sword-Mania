using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    
    private bool collisionTrigger = false;

    private SpriteRenderer spriterenderer;
    public float speed = 10f;
    public int health = 100;

    public int moneyGained = 50;

     

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Wall" && collisionTrigger ==false ){

            spriterenderer.flipX = true;
            collisionTrigger = true;
            
 
        }
        else if(collision.gameObject.tag =="Wall" && collisionTrigger == true){
            spriterenderer.flipX = false;
            collisionTrigger = false;
        }
    }
    

    private void Awake() {
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Die();
        }

        void Die()
        {            
            Destroy(gameObject);
        }
    }

    private void Update() {
       float speedAmount = speed * Time.deltaTime;
        if (spriterenderer.flipX == false){
            transform.Translate(speedAmount,0,0);
        } 
        else{
             
        transform.Translate(-speedAmount,0,0);

        }

        
        
    }

    
}
