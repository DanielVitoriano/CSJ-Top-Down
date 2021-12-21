using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{
    public dialogue_settings dialogue;
    public float dialogue_ranger;
    public LayerMask player;
    private bool player_hit;
    private List<string> sentences = new List<string>();

    private void Start() {
        get_npc_info();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.E) && player_hit){
            Dialogue_controller.instance.Speech(sentences.ToArray());
        }
    }
    private void FixedUpdate() {
        show_dialogue();
    }

    private void show_dialogue(){
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogue_ranger, player);

        if(hit != null){
            player_hit = true;
        }
        else{
            player_hit = false;
        }

    }
    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, dialogue_ranger);
    }

    private void get_npc_info(){
        for(int c = 0; c < dialogue.dialogues.Count; c++){
            switch(Dialogue_controller.instance.languages){
                case Dialogue_controller.language.pt:
                    sentences.Add(dialogue.dialogues[c].sentence.portuguese);
                    break;

                case Dialogue_controller.language.eng:
                    sentences.Add(dialogue.dialogues[c].sentence.english);
                    break;
                
                case Dialogue_controller.language.spa:
                    sentences.Add(dialogue.dialogues[c].sentence.spanish);
                    break;
            }   
        }

        
    }
}
