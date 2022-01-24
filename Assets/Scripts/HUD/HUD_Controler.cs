using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Controler : MonoBehaviour
{
    [Header("Itens")]
    [SerializeField] private Image woodUI;
    [SerializeField] private Image carrotsUI;
    [SerializeField] private Image waterUI;
    [SerializeField] private Image fishesUI;
    [Header("Player")]
    [SerializeField] private Image healthBar;
    [SerializeField] private Image staminaBar;

    [Header("Tools")]
    [SerializeField] List<Image> toolsUI = new List<Image>();
    public Color selectedItenColor;
    public Color unnselectItenColor;

    // Start is called before the first frame update
    void Start()
    {
        woodUI.fillAmount = 0f;
        carrotsUI.fillAmount = 0f;
        waterUI.fillAmount = 0f;
        fishesUI.fillAmount = 0f;
    }

    
    public void setWoodUIBar(float current, float limit){
        woodUI.fillAmount = current / limit;
    }

    public void setCarrotsUIBar(float current, float limit){
       carrotsUI.fillAmount = current / limit;
    }

    public void setWaterUIBar(float current, float limit){
        waterUI.fillAmount = current / limit;
    }

    public void setFishesUIBar(float current, float limit){
        fishesUI.fillAmount = current / limit;
    }

    public void setSelectIten(int selectedIten){
        for(int x = 0; x < toolsUI.Count; x++){
            if(selectedIten == x) toolsUI[x].color = selectedItenColor;
            else toolsUI[x].color = unnselectItenColor;
        }
    }

    public void SetHealthBarFillAmount(float value){
        healthBar.fillAmount = value;
    }
    public void SetStaminaBarFillAmount(float value){
        staminaBar.fillAmount = value;
    }

}
