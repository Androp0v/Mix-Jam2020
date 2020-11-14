using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyMob : BaseMob
{
    // Override StartSpecific
    override public void StartSpecific(){
        Debug.Log("Bunny started");
        mobType = BUNNY_MOB;
        // Initialize behaviour
        behaviour = new BunnyBehaviour();
        behaviour.attachedMob = this;
    }
}
