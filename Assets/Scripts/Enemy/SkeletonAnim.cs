using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAnim : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask playerLayer;
    private Player_anim player_Anim;
    private Skeleton skeleton;

    private Animator anim;

    private void Awake() {
        anim = GetComponent<Animator>();
        player_Anim = FindObjectOfType<Player_anim>();
        skeleton = GetComponentInParent<Skeleton>();
    }

    public void PlayAnim(int value){
        anim.SetInteger("Transition", value);
    }

    public void Attack(){
        Collider2D collAttack = Physics2D.OverlapCircle(attackPoint.position, radius, playerLayer);

        if(collAttack != null){
            player_Anim.OnHit(skeleton.Damage);
        }

    }

    public void OnHit(int damage){
        anim.SetTrigger("Hurt");
        skeleton.OnHit(damage);
    }
    public void OnDeath(){
        anim.SetTrigger("Death");
        Destroy(gameObject, 1);
    }

    private void OnDrawGizmosSelected(){
        Gizmos.DrawWireSphere(attackPoint.position, radius);
    }

}
