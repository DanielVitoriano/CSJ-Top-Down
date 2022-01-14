using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItens : MonoBehaviour
{

    private float woods;
    private float water;
    private int carrots;
    private int fishes;

    [SerializeField] private float waterLimit;
    [SerializeField] private float woodLimit;
    [SerializeField] private int carrotsLimit;
    [SerializeField] private int fishesLimit;

    public float WaterLimit { get => waterLimit; set => waterLimit = value; }
    public float WoodLimit { get => woodLimit; set => woodLimit = value; }
    public int CarrotsLimit { get => carrotsLimit; set => carrotsLimit = value; }
    public float Woods { get => woods; set => woods = value; }
    public float Water { get => water; set => water = value; }
    public int Carrots { get => carrots; set => carrots = value; }

    private HUD_Controler hud_controler;

    private void Awake() {
        hud_controler = FindObjectOfType<HUD_Controler>();
    }

    public void setWater(float increase){
        Water += increase;
        if(Water > WaterLimit){ Water -= (Water - WaterLimit);}
        hud_controler.setWaterUIBar(Water, waterLimit);
    }
    public void setWood(float increase){
        this.Woods += increase;
        if(Woods > WoodLimit){ Woods -= (Woods - WoodLimit);}
        hud_controler.setWoodUIBar(Woods, woodLimit);
    }
    public void setCarrots(int increase){
        this.Carrots += increase;
        if(Carrots > CarrotsLimit){ Carrots -= (Carrots - CarrotsLimit);}
        hud_controler.setCarrotsUIBar(Carrots, carrotsLimit);
    }
    public void setFishes(int increase){
        this.fishes += increase;
        if(fishes > fishesLimit){ fishes -= (fishes - fishesLimit);}
        hud_controler.setFishesUIBar(fishes, fishesLimit);
    }

}