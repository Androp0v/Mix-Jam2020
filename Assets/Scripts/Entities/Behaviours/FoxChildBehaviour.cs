using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxChildBehaviour : BaseBehaviour
{
    private double _maturityAge = 30;

    // Move function, default to random walk
    override public void Move(){

        // DEFAULT TO RANDOM WALK

        randomWalk();

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
