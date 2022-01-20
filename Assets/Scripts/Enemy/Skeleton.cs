using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Skeleton : MonoBehaviour
{
    public float radius;
    public LayerMask playerLayer;
    private bool detectPlayer = false;
    [SerializeField] private int damage;
    [SerializeField] private NavMeshAgent agent;
    private Player player;
    [SerializeField] private SkeletonAnim skeletonAnim;
    private float currentHealth;
    [SerializeField] private float totalHealth;
    [SerializeField] private Image healBar;
    private bool death;

    public int Damage { get => damage; set => damage = value; }

    private void Awake() {
        player = FindObjectOfType<Player>();
    }

    private void Start() {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        currentHealth = totalHealth;
    }

    private void FixedUpdate() {
        DetectPlayer();
    }

    private void Update() {
       if(!death && detectPlayer){
            agent.isStopped = false;
            agent.SetDestination(player.transform.position);

            if(Vector2.Distance(transform.position, player.transform.position) <= agent.stoppingDistance){
                skeletonAnim.PlayAnim(2);
            }
            else{
                skeletonAnim.PlayAnim(1);
            }

            float posX = player.transform.position.x - transform.position.x;

            if(posX > 0){
                transform.eulerAngles = new Vector2(0, 0);
            }
            else{
                transform.eulerAngles = new Vector2(0, 180);
            }
       }
    }

    public void OnHit(int damage){
        currentHealth -= damage;
        healBar.fillAmount = currentHealth / totalHealth;
        if(currentHealth <= 0){
            GetComponent<Collider2D>().enabled = false;
            death = true;
            skeletonAnim.OnDeath();
            Destroy(gameObject, 1);
        }
    }

    public void DetectPlayer(){
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, playerLayer);

        if(hit != null){ 
            detectPlayer = true;
        }
        else { 
            detectPlayer = false; 
            skeletonAnim.PlayAnim(0);
            agent.isStopped = true;
        }
    }
    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
