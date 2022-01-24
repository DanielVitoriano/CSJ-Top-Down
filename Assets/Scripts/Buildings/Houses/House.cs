using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class House : MonoBehaviour
{
    [SerializeField] private int woodAmount;
    [SerializeField] private SpriteRenderer houseSprite;
    [SerializeField] private Color startColor;
    [SerializeField] private Color endColor;
    [SerializeField] private float timeAmount;
    [SerializeField] private Transform point;
    [SerializeField] private GameObject coll;
    [SerializeField] private GameObject recursos;
    [SerializeField] private Text tem;
    [SerializeField] private Text precisa;
    private float timeCount;
    private bool isBegining;
    private bool builded;

private Player_anim player_anim;
    private PlayerItens playerItens;
    private bool detectingPlayer;

    private void Awake() {
        playerItens = FindObjectOfType<PlayerItens>();
        player_anim = playerItens.GetComponent<Player_anim>();
    }

    private void Update() {

        if(detectingPlayer && !builded){
            recursos.SetActive(true);
            tem.text = playerItens.Woods.ToString();
            precisa.text = woodAmount.ToString();
        }
        else{recursos.SetActive(false);}

        if(!builded && detectingPlayer && Input.GetKeyDown(KeyCode.E) && playerItens.Woods >= woodAmount){
            builded = true;
            playerItens.setWood(-woodAmount);
            isBegining = true;
            player_anim.OnHammeringStarted();
            houseSprite.color = startColor;
            playerItens.transform.position = point.position;
            playerItens.transform.rotation = point.transform.rotation;

        }
        if(isBegining){
            timeCount += Time.deltaTime;
            if(timeCount >= timeAmount){
                player_anim.OnHammeringEnded();
                houseSprite.color = endColor;
                coll.SetActive(true);
            }
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
