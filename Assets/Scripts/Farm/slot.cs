using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slot : MonoBehaviour
{
    [Header("Configurações")]
    [SerializeField] private int digAmount;
    private float currentWater;
    [SerializeField] private int waterAmount;
    private int initDigAmount;
    private bool dugHole;
    [SerializeField] private bool detecting;
    private bool plantedCarrot;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip holeSFX;
    [SerializeField] private AudioClip carrotSFX;

    [Header("Componentes")]
    public SpriteRenderer sprite;
    [SerializeField]
    private Sprite hole;
    [SerializeField]
    private Sprite carrot;
    PlayerItens player_itens;

    public int DigAmount { get => digAmount; set => digAmount = value; }

    private void Start() {
        initDigAmount = DigAmount;
        player_itens = FindObjectOfType<PlayerItens>();
    }
    private void Update() {
        if(dugHole){
            if(detecting){
                currentWater += 0.01f;
            }
            if(currentWater >= waterAmount && !plantedCarrot){
                sprite.sprite = carrot;
                audioSource.PlayOneShot(holeSFX);

                plantedCarrot = true;
            }
            
            if(Input.GetKeyDown(KeyCode.E) && plantedCarrot){
                sprite.sprite = hole;
                player_itens.setCarrots(1);
                currentWater = 0f;
                audioSource.PlayOneShot(carrotSFX);
            }
        }
    }
    public void OnHit(){

        DigAmount --;

        if(DigAmount <= initDigAmount / 2){
            sprite.sprite = hole;
            dugHole = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Shovel") & DigAmount >= 0){
            OnHit();
        }
        if(other.CompareTag("water")){
            detecting = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("water")){
            detecting = false;
        }
    }
}
