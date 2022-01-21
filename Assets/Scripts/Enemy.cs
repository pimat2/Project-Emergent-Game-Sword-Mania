using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
     
    public int healthGain = 1;
    public int healthGainChance = 5;
    private bool collisionTrigger = false;
    private SpriteRenderer spriterenderer;
    public int maxHealth = 100;
    int currentHealth;
    public float speed = 10f;
    public int moneyGained = 50;
    private void OnCollisionEnter2D(Collision2D collision) { //makes enemies flip sprites when they collide with walls so that they change direction of movement
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
            int randomNumber = Random.Range(0, healthGainChance);
            if(randomNumber == 1){
                PlayerStats.Lives = PlayerStats.Lives + healthGain;
            }
            PlayerStats.Money = PlayerStats.Money + moneyGained;
             Destroy(gameObject); //when an enemy is killed there's a chance for the player to gain health
             
        }
        
    }

    private void Update() {
       float speedAmount = speed * Time.deltaTime; //enemy movement
        if (spriterenderer.flipX == false){
            transform.Translate(speedAmount,0,0);
        } 
        else{
        transform.Translate(-speedAmount,0,0);
        }
    }

    
}
