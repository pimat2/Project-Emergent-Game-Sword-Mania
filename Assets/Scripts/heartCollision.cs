using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartCollision : MonoBehaviour
{

    public GameObject heroSprite;
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Enemy"){
            var heroRenderer = heroSprite.GetComponent<Renderer>();
            heroRenderer.material.SetColor("_Color",Color.red);//changes color of Hero object when enemies enter collision with Heart object
            PlayerStats.Lives = PlayerStats.Lives - 1; //substracts 1 life from the player when an enemy collides with the heart object
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.gameObject.tag =="Enemy"){
            var heroRenderer = heroSprite.GetComponent<Renderer>();//Reverts back to the normal Hero object color when enemies exit the Heart object boxcollider
            heroRenderer.material.SetColor("_Color",Color.white);
        }
        
    }
    
}
