using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_controller : MonoBehaviour
{

    [System.Serializable]
    public enum language{
        pt, eng, spa
    }
    public language languages;

    [Header("COMPONENTS")]
    public GameObject dialogueObj;
    public Image profileSprite;
    public Text speechText;
    public Text actorNameText;

    [Header("SETTINGS")]
    public float typingSpeed;

    //controle
    private bool isShowing;
    private int index;
    private string[] sentences;
    private string[] currentActorName;
    private Sprite[] currentProfileSprite;
    private Player player;

    public static Dialogue_controller instance;

    public bool IsShowing { get => isShowing; set => isShowing = value; }

    private void Awake(){
        instance = this;
        player = FindObjectOfType<Player>();
    }

    IEnumerator typeSentences(){
        foreach(char letter in sentences[index].ToCharArray()){
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence(){ //próxima frase
        if(speechText.text == sentences[index]){
            if(index < sentences.Length - 1){
                index++;
                speechText.text = "";
                StartCoroutine(typeSentences());
            }
            else{//termina os textos
                speechText.text = "";
                index = 0;
                actorNameText.text = null;
                dialogueObj.SetActive(false);
                sentences = null;
                IsShowing = false;
                player.isPaused = false;
            }
        }
    }
    public void Speech(string[] txt, string[] actorNameM, Sprite[] profileSpriteM){ //falar com npc
    if(!IsShowing){
        dialogueObj.SetActive(true);
        sentences = txt;
        currentActorName = actorNameM;
        currentProfileSprite = profileSpriteM;
        profileSprite.sprite = currentProfileSprite[index];
        actorNameText.text = currentActorName[index];
        StartCoroutine(typeSentences());
        IsShowing = true;
        player.isPaused = true;
    }

    }

}
