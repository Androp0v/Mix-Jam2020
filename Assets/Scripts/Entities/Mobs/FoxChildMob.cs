using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxChildMob : BaseMob
{
    // Override StartSpecific
    override public void StartSpecific(){
        mobType = FOX_MOB_CHILD;
        // Initialize behaviour
        behaviour = new FoxChildBehaviour();
        behaviour.attachedMob = this;
    }
}
