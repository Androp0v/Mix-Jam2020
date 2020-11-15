using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotBehaviour : BaseBehaviour
{
    override public void Move(){

        // MATING (Only accidental for this mobs, not seeked)
        checkIfMating();

        randomWalk();
    }
}
