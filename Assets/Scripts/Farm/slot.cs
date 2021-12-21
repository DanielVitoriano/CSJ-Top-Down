using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slot : MonoBehaviour
{
    [SerializeField]
    private int digAmount;
    private int initDigAmount;
    public SpriteRenderer sprite;
    [SerializeField]
    private Sprite hole;
    [SerializeField]
    private Sprite carrot;

    public int DigAmount { get => digAmount; set => digAmount = value; }

    private void Start() {
        initDigAmount = DigAmount;
    }

    public void OnHit(){

        DigAmount --;

        if(DigAmount <= initDigAmount / 2){
            sprite.sprite = hole;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Shovel") & DigAmount >= 0){
            OnHit();
        }
    }
}
