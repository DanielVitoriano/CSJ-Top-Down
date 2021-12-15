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

    public static Dialogue_controller instance;

    public bool IsShowing { get => isShowing; set => isShowing = value; }

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
        if(speechText.text == sentences[index]){
            if(index < sentences.Length - 1){
                index++;
                speechText.text = "";
                StartCoroutine(typeSentences());
            }
            else{//termina os textos
                speechText.text = "";
                index = 0;
                dialogueObj.SetActive(false);
                sentences = null;
                IsShowing = false;
            }
        }
    }
    public void Speech(string[] txt){ //falar com npc
    if(!IsShowing){
        dialogueObj.SetActive(true);
        sentences = txt;
        StartCoroutine(typeSentences());
        IsShowing = true;
    }

    }

}
