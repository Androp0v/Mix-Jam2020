using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyChildMob : BaseMob
{
    // Override StartSpecific
    override public void StartSpecific(){
        mobType = BUNNY_MOB_CHILD;
        // Initialize behaviour
        behaviour = new BunnyChildBehaviour();
        behaviour.attachedMob = this;
    }
}
