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
        if (direction.HasValue){
            Vector2 moveDirection = direction ?? Vector2.zero;
            attachedMob.rigidBody.velocity = moveDirection;
        }
        
    }

    // Move function, default to random walk
    override public void Move(){

        // FOOD SEEKING

        Vector2? directionFood = new Vector2();
        int? foodID = 0;
        (directionFood, foodID) = getClosestFood(BaseMob.STATIC_FOOD);

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

        // MAP BOUNDS CHECK
        if (attachedMob.rigidBody.velocity == Vector2.zero){
            randomWalk();
        }
        if (checkIfOutsideMap()){
            attachedMob.rigidBody.velocity = Vector2.zero;
        }


    }
}