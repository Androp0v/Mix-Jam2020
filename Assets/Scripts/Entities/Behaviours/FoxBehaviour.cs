using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxBehaviour : BaseBehaviour
{
    // Move function, default to random walk
    override public void Move(){

        // FOOD SEEKING

        Vector2? directionFood = new Vector2();
        int? foodID = 0;
        (directionFood, foodID) = getClosestFood(BaseMob.BUNNY_MOB);

        // MATE SEEKING

        Vector2? directionMating = new Vector2();
        int? matingID = 0;
        (directionMating, matingID) = getClosestMatingPartner();

        checkIfMating();

        // If direction is not null it means it has found a close food
        if (directionFood.HasValue || directionMating.HasValue){
            //Debug.Log("Food or mating have values");

            if (directionMating == null){
                // If there's food nearby, try to get it
                Vector2 moveDirection = ( directionFood ?? Vector2.zero ).normalized;
                attachedMob.rigidBody.velocity = moveDirection * attachedMob.getMobSpeed();
            } else if (directionFood == null){
                //Debug.Log("Food is null");
                // If there's mating opportunities nearby, try to get it
                Vector2 moveDirection = ( directionMating ?? Vector2.zero ).normalized;
                attachedMob.rigidBody.velocity = moveDirection * attachedMob.getMobSpeed();
            } else {
                //Debug.Log("Neither food nor mating are null");
                Vector2 directionFoodUnwrapped = directionFood ?? Vector2.zero;
                Vector2 directionMatingUnwrapped = directionMating ?? Vector2.zero;
                if (directionFoodUnwrapped.magnitude < directionMatingUnwrapped.magnitude){
                    // If there's mating opportunities nearby, try to get it
                    Vector2 moveDirection = ( directionMating ?? Vector2.zero ).normalized;
                    attachedMob.rigidBody.velocity = moveDirection * attachedMob.getMobSpeed();
                } else {
                    // If there's mating opportunities nearby, try to get it
                    Vector2 moveDirection = ( directionMating ?? Vector2.zero ).normalized;
                    attachedMob.rigidBody.velocity = moveDirection * attachedMob.getMobSpeed();
                }
            }

        } else {
            randomWalk();
        }
    }
    
}
