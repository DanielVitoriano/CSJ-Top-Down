using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItens : MonoBehaviour
{

    public float woods;
    public float water;

    [SerializeField] private float waterLimit;
    [SerializeField] private float woodLimit;

    public void setWater(float increase){
        water += increase;
        if(water > waterLimit){ water -= (water - waterLimit);}
    }
    public void setWood(float increase){
        this.woods += increase;
        if(woods > woodLimit){ woods -= (woods - woodLimit);}
    }

}