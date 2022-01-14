using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_anim : MonoBehaviour
{
    private Animator anim;
    private Player player;
    private fishing fishing;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<Player>();
        fishing = FindObjectOfType<fishing>();
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();
        OnRun();
    }

    #region Movement
    private void OnMove(){
        if(player.direction.sqrMagnitude > 0){
            if(player.isRolling){// player rolando
                anim.SetTrigger("isRoll");
            }
            else{ //player andando
                anim.SetInteger("transition", 1);
            }
        }
        else{
            anim.SetInteger("transition", 0);
        }

        if(player.direction.x > 0){
            transform.eulerAngles = new Vector2(0, 0);
        }
        if(player.direction.x < 0){
            transform.eulerAngles = new Vector2(0, 180);
        }
        
        if(player.isCutting){
            anim.SetInteger("transition", 3);
        }
        if(player.isDigging){
            anim.SetInteger("transition", 4);
        }
        if(player.isWatering){
            anim.SetInteger("transition", 5);
        }
    }
    private void OnRun(){
        if(player.isRunning){
            anim.SetInteger("transition", 2);
        }
    }
    public void OnFishingStarted(){
        anim.SetTrigger("isFishing");
        player.isPaused = true;
    }
    private void OnFishingEnd(){
        fishing.OnFishing();
        player.isPaused = false;
    }

    public void OnHammeringStarted(){
        anim.SetBool("Hammering", true);
        player.isPaused = true;
    }
    
    public void OnHammeringEnded(){
        anim.SetBool("Hammering", false);
        player.isPaused = false;
    }
    #endregion
}
