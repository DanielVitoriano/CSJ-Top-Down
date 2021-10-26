using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_anim : MonoBehaviour
{
    private Animator anim;
    private Player player;
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<Player>();
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
    }
    private void OnRun(){
        if(player.isRunning){
            anim.SetInteger("transition", 2);
        }
    }


    #endregion
}
