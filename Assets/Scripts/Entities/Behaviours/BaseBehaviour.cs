using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class BaseBehaviour
{   
    // BEHAVIOUR PROPERTIES
    public BaseMob attachedMob;
    
    // Retrieve closest food
    public virtual (Vector2?, int?) getClosestFood(){

        double minFoodDistance = double.MaxValue;
        Vector2 closestFoodPosition = Vector2.zero;
        int closestFoodID = -1; // Set initial closestFoodID to -1 (invalid, all IDs are chosen positive in the manager)
        MobManager manager = attachedMob.manager;

        // Loop over all entities to find closest food
        foreach (int uniqueID in attachedMob.manager.allIDs){
            // Check that the mobDict actually contains that mob ID
            if (manager.mobDict.ContainsKey(uniqueID)){

                BaseMob otherMob = manager.mobDict[uniqueID];

                // Check if the otherMob is food
                if (otherMob.mobType == BaseMob.STATIC_FOOD){
                    // Distance to food item
                    double distance = Vector2.Distance(attachedMob.rigidBody.position, otherMob.rigidBody.position);
                    // If distance is closer than the last distance saved, update the closest distance and ID
                    if (distance < minFoodDistance){
                        minFoodDistance = distance;
                        closestFoodID = uniqueID;
                        closestFoodPosition = otherMob.rigidBody.position;
                    }
                }

            } else {
                Debug.Log("Mob ID not in dictionary!");
            }
        }

        // If a valid food is encountered, return its ID and direction
        if (closestFoodID != -1) {
            Vector2 direction = new Vector2(closestFoodPosition.x - attachedMob.rigidBody.position.x,
                                            closestFoodPosition.y - attachedMob.rigidBody.position.y);
            return (direction, closestFoodID);
        }
        
        return (null,null);
    }
    
    // Random Walk function (idle)
    protected void randomWalk(){
        // TO-DO RANDOM WALK HERE
    }

    // Move function, default to random walk
    public abstract void Move();
}
