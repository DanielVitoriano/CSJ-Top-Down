using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree : MonoBehaviour
{

    [SerializeField] private float health;
    [SerializeField] private ParticleSystem leafs;
    private bool alive = true;
    private Animator anim;
    public GameObject wood;
    private void Start() {
        anim = GetComponent<Animator>();
    }

    public void OnHit(){
        health --;

        anim.SetTrigger("isHit");
        leafs.Play();

        if(health <= 0){
            alive = false;
            int amountWood = Random.Range(1, 6);

            for(int x = 0; x <= amountWood; x++){
                Instantiate(wood, transform.position, transform.rotation);
            }

            anim.SetTrigger("cut");
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("axe") && alive ){
            OnHit();
        }
    }
}
