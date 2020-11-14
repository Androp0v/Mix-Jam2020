using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyBehaviour : BaseBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        Vector2? direction = new Vector2();
        int? foodID = 0;
        (direction, foodID) = getClosestFood(BaseMob.STATIC_FOOD);
        Debug.Log("No food found");
        if (direction.HasValue){
            Debug.Log("There's a direction");
            Vector2 moveDirection = direction ?? Vector2.zero;
            attachedMob.rigidBody.velocity = moveDirection;
        }
        
    }

    // Move function, default to random walk
    override public void Move(){

        // PREDATOR CHECK

        checkPredatorTooClose(BaseMob.FOX_MOB);

        // FOOD SEEKING

        Vector2? direction = new Vector2();
        int? foodID = 0;
        (direction, foodID) = getClosestFood(BaseMob.STATIC_FOOD);

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