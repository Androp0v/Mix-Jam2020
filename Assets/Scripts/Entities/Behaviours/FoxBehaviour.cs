using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxBehaviour : BaseBehaviour
{
    // Move function, default to random walk
    override public void Move(){

        // FOOD SEEKING

        Vector2? direction = new Vector2();
        int? foodID = 0;
        (direction, foodID) = getClosestFood(BaseMob.FOX_MOB);

        // If direction is not null it means it has found a close food
        if (direction.HasValue){

            // If there's food nearbay, try to get it
            Vector2 moveDirection = ( direction ?? Vector2.zero ).normalized;
            attachedMob.rigidBody.velocity = moveDirection * attachedMob.getMobSpeed();

        } else {
            randomWalk();
        }
    }
    
}
