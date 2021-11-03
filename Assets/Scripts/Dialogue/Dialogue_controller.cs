using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_controller : MonoBehaviour
{

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

    public static Dialogue_controller instance;

    private void Awake(){
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator typeSentences(){
        foreach(char letter in sentences[index].ToCharArray()){
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence(){ //próxima frase

    }
    public void Speech(string[] txt){ //falar com npc
    if(!isShowing){
        dialogueObj.SetActive(true);
        sentences = txt;
        StartCoroutine(typeSentences());
        isShowing = true;
    }

    }

}
