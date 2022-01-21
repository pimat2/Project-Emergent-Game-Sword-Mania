using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool collisionTrigger = false;
    private SpriteRenderer spriterenderer;
    public int maxHealth = 100;
    int currentHealth;
    public float speed = 10f;
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
    private void Start() {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            PlayerStats.Money = PlayerStats.Money + moneyGained;
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
