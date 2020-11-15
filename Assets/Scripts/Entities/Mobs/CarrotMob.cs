using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotMob : BaseMob
{
    // Override StartSpecific
    override public void StartSpecific(){
        mobType = CARROT_MOB;
        // Initialize behaviour
        behaviour = new CarrotBehaviour();
        behaviour.attachedMob = this;
    }
}
