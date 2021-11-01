using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{

    public float dialogue_ranger;
    public LayerMask player;

    // Start is called before the first frame update
    private void FixedUpdate() {
        show_dialogue();
    }

    private void show_dialogue(){
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogue_ranger, player);

        if(hit != null){
            
        }

    }
    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, dialogue_ranger);
    }
}
