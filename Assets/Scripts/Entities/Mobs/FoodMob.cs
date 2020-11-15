using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMob : BaseMob
{   

    override public double getMaxAge(){
        return float.MaxValue; // Food doesn't die of old age
    }

    // Override StartSpecific
    override public void StartSpecific(){
        Debug.Log("Food started");
        mobType = STATIC_FOOD;
        // Initialize behaviour
        behaviour = new StaticFoodBehaviour();
        behaviour.attachedMob = this;
    }

}
