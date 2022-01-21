using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    
    public LayerMask enemyLayer;
    public Animator animator;
    public int damageAmount = 1;
    private float cooldown = 0.5f;
    private float lastSwing;
    public float attackRange = 0.5f;
    public Transform attackPoint;

     

    private void Update() {
        if(Input.GetMouseButtonDown(0)){
            if(Time.time - lastSwing > cooldown){
                lastSwing = Time.time;
                Attack();
            }
        }
         
        
    }

    void Attack(){
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies =  Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach(Collider2D enemy in hitEnemies){
            enemy.GetComponent<Enemy>().TakeDamage(damageAmount);
        }
    }
    private void OnDrawGizmosSelected() { //easier to see the attack radius 

        if(attackPoint==null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
        
    }
    
}
