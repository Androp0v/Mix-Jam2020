using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotChildMob : BaseMob
{
    // Override StartSpecific
    override public void StartSpecific(){
        mobType = STATIC_FOOD;
        // Initialize behaviour
        behaviour = new CarrotChildBehaviour();
        behaviour.attachedMob = this;
    }
}
