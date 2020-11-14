﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxMob : BaseMob
{
    // Override StartSpecific
    override public void StartSpecific(){
        Debug.Log("Fox started");
        mobType = FOX_MOB;
        // Initialize behaviour
        behaviour = new FoxBehaviour();
        behaviour.attachedMob = this;
    }
}