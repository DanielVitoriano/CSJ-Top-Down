using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishing : MonoBehaviour
{
    [SerializeField] Fish fish;
    private bool detectingPlayer;
    private int percentage = 40;
    private Player player;

    private Player_anim player_anim;

    private void Start() {
        player_anim = FindObjectOfType<Player_anim>();
        player = FindObjectOfType<Player>();
    }

    private void Update() {
        if(detectingPlayer && Input.GetKeyDown(KeyCode.E)){
            player_anim.OnFishingStarted();
        }
    }

    public void OnFishing(){
        int randomValue = Random.Range(1, 100);
        if(randomValue <= percentage){
            Instantiate(fish, player.transform.position + new Vector3(Random.Range(-1, 1), Random.Range(1, 2), 0), player.transform.rotation);
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
