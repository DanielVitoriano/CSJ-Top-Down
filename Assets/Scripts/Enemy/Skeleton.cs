using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    private Player player;
    [SerializeField] private SkeletonAnim skeletonAnim;
    
    private void Awake() {
        player = FindObjectOfType<Player>();
    }

    private void Start() {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update() {
        agent.SetDestination(player.transform.position);

        if(Vector2.Distance(transform.position, player.transform.position) <= agent.stoppingDistance){
            skeletonAnim.PlayAnim(1);
        }
        else{
            skeletonAnim.PlayAnim(0);
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
