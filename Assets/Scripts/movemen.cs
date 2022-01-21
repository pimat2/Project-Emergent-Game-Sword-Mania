using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movemen : MonoBehaviour
{

    public GameObject weaponObject;
    public Animator animator;
    public float cooldownTimer;
    private bool jumpCooldown = false;
    private SpriteRenderer spriteRenderer;
    public float speed;
    public Vector2 jumpHeight;
    
    void Awake()
    {
       spriteRenderer = GetComponent<SpriteRenderer>();
    }

void ResetCooldown(){
        jumpCooldown = false;
    }

    void Update()
    {
       //movement of the player plus sprite flipping
        float speedAmount = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(speedAmount,0,0);
        if(speedAmount<0){
            transform.localScale = new Vector3(-4,4,4);
        }
        if(speedAmount>0){
            transform.localScale = new Vector3(4,4,4);
        }
        
        animator.SetFloat("Speed", Mathf.Abs(speedAmount));
        
        
        if ( Input.GetKeyDown(KeyCode.Space))  //makes player jump
    {
        if(jumpCooldown == false){ //cooldown so that players can't spam the jump key
            GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
            Invoke("ResetCooldown", cooldownTimer);
            jumpCooldown = true;

        }
    }
}
}
