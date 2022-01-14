using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour
{

    [SerializeField]
    private int waterIncrease;
    private PlayerItens playerItens;
    private bool detectingPlayer;

    public int WaterIncrease { get => waterIncrease; set => waterIncrease = value; }

    private void Start() {
        playerItens = FindObjectOfType<PlayerItens>();
    }

    private void Update() {
        if(detectingPlayer && Input.GetKeyDown(KeyCode.E)){
            playerItens.setWater(waterIncrease);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            detectingPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")){
            detectingPlayer = false;
        }
    }
}
