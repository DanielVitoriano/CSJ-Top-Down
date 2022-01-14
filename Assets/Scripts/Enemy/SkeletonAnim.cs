using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAnim : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask playerLayer;

    private Animator anim;

    private void Awake() {
        anim = GetComponent<Animator>();
    }

    public void PlayAnim(int value){
        anim.SetInteger("Transition", value);
    }

    public void Attack(){
        Collider2D collAttack = Physics2D.OverlapCircle(attackPoint.position, radius, playerLayer);

         if(collAttack != null){
             
        }

    }

    private void OnDrawGizmosSelected(){
        Gizmos.DrawWireSphere(attackPoint.position, radius);
    }

}
