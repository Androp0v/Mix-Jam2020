using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyChildBehaviour : BaseBehaviour
{

    private double _maturityAge = 30;

    // Move function, default to random walk
    override public void Move(){

        // DEFAULT TO RANDOM WALK

        randomWalk();

        // PREDATOR CHECK

        checkPredatorTooClose(BaseMob.FOX_MOB);

        Vector2? directionPredator = new Vector2();
        int? predatorID = 0;
        (directionPredator, predatorID) = getClosestPredator(BaseMob.FOX_MOB);

        if (directionPredator.HasValue){
            // If there's food nearby, try to get it
            Vector2 moveDirection = ( -directionPredator ?? Vector2.zero ).normalized;
            attachedMob.rigidBody.velocity = moveDirection * attachedMob.getMobSpeed();
        }

        // CHECK IF IT SHOULD GROW UP
        if (attachedMob.getAge() > _maturityAge){
            GameObject child = GameObject.Instantiate(attachedMob.mobPrefab, attachedMob.rigidBody.position, Quaternion.identity);
            attachedMob.OnDeath();
        }

        // MAP BOUNDS CHECK
        if (attachedMob.rigidBody.velocity == Vector2.zero){
            randomWalk();
        }
        if (checkIfOutsideMap()){
            attachedMob.rigidBody.velocity = Vector2.zero;
        }

    }
}
