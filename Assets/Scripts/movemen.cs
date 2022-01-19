using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movemen : MonoBehaviour
{
    public float cooldownTimer;
    private bool cooldown = false;
    private SpriteRenderer spriteRenderer;
    public float speed;
    public Vector2 jumpHeight;
    // Start is called before the first frame update
    void Awake()
    {
       spriteRenderer = GetComponent<SpriteRenderer>();
    }

void ResetCooldown(){
        cooldown = false;

    }
    // Update is called once per frame
    void Update()
    {
       //movement of the player plus sprite flipping
        float speedAmount = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(speedAmount,0,0);
        if(speedAmount<0){
            spriteRenderer.flipX=true;
        }
        if(speedAmount>0){
            spriteRenderer.flipX=false;
        }
        
        
        
        
        
        
        
        if ( Input.GetKeyDown(KeyCode.Space))  //makes player jump
    {
        if(cooldown == false){ //cooldown so that players can't spam the jump key
            GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
            Invoke("ResetCooldown", cooldownTimer);
            cooldown = true;

        }
        

    }
    
        
    
}
}
