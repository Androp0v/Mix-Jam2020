using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BaseBehaviour
{   
    // BEHAVIOUR PROPERTIES
    public BaseMob attachedMob;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Retrieve closest food
    public virtual (Vector2?, double?) getClosestFood(Rigidbody2D rigidbody){

        double minFoodDistance = double.MaxValue;

        // Loop over all entities to find closest food
        foreach (int uniqueID in attachedMob.manager.allIDs){

            if (attachedMob.manager.mobDict.ContainsKey(uniqueID)){
                /*switch (attachedMob.manager.mobDict.GetType){
                    // TO-DO case FoodMob
                    default:
                        // Do nothing
                }*/
            } else {
                Debug.Log("Mob ID not in dictionary!");
            }
        }
        
        return (null,null);
    }
    
    // Random Walk function (idle)
    protected void randomWalk(Rigidbody2D _rigidBody){
        // TO-DO RANDOM WALK HERE
    }

    // Move function, default to random walk
    public virtual void Move(Rigidbody2D rigidBody){
        randomWalk(rigidBody);
    }
}
