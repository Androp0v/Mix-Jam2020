using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class BaseBehaviour
{   
    // BEHAVIOUR PROPERTIES
    public BaseMob attachedMob;
    public int predatorKillRadius = 1;
    public int matingRadius = 1;

    // USED FOR RANDOM WALK
    private Vector2 _oldDirection = new Vector2(0,0);
    private Vector2 _nextDirection = new Vector2(0,0);
    private Vector2 _movementDirection = new Vector2(0,0);
    private int _currentSteps = 0;
    private const int interpolatingSteps = 30;
    
    // Check if it's mating
    public virtual void checkIfMating(){

        MobManager manager = attachedMob.manager;

        // Loop over all entities to find closest predator
        foreach (int uniqueID in attachedMob.manager.getAllIDs()){
            // Check that the mobDict actually contains that mob ID
            if (manager.mobDict.ContainsKey(uniqueID)){

                BaseMob otherMob = manager.mobDict[uniqueID];
                
                // Check if the otherMob is a predator for a given class
                if (otherMob.mobType == attachedMob.mobType){
                    // Distance to predator
                    double distance = Vector2.Distance(attachedMob.rigidBody.position, otherMob.rigidBody.position);
                    
                    if ((distance < matingRadius) && (otherMob.wantsToMate() && attachedMob.wantsToMate())){
                        attachedMob.timeSinceLastMating = 0;
                        otherMob.timeSinceLastMating = 0;
                        Debug.Log("THEY MATED!");
                        return;
                    }
                }

            } else {
                Debug.Log("uniqueID not in list: " + uniqueID.ToString());
            }
        }
    }

    // Check if another creature is close to mate
    public virtual (Vector2?, int?) getClosestMatingPartner(){

        // Check that the timeframe after last mating is enough
        if (!attachedMob.wantsToMate()){
            return (null, null);
        }

        double minFoodDistance = double.MaxValue;
        Vector2 closestFoodPosition = Vector2.zero;
        int closestFoodID = -1; // Set initial closestFoodID to -1 (invalid, all IDs are chosen positive in the manager)
        MobManager manager = attachedMob.manager;

        // Loop over all entities to find closest food
        foreach (int uniqueID in attachedMob.manager.getAllIDs()){
            // Check that the mobDict actually contains that mob ID
            if (manager.mobDict.ContainsKey(uniqueID)){

                BaseMob otherMob = manager.mobDict[uniqueID];

                // Check if the otherMob is food
                if ((otherMob.mobType == attachedMob.mobType) && (otherMob.managerID != attachedMob.managerID)){
                    // Distance to food item
                    double distance = Vector2.Distance(attachedMob.rigidBody.position, otherMob.rigidBody.position);
                    // If distance is closer than the last distance saved, update the closest distance and ID
                    if ((distance < minFoodDistance) & (distance < attachedMob.getSeekingFoodRadius())){
                        minFoodDistance = distance;
                        closestFoodID = uniqueID;
                        closestFoodPosition = otherMob.rigidBody.position;
                    }
                }

            } else {
                Debug.Log("uniqueID not in list: " + uniqueID.ToString());
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

    // Check predator too close
    public virtual void checkPredatorTooClose(int predatorType){

        MobManager manager = attachedMob.manager;

        // Loop over all entities to find closest predator
        foreach (int uniqueID in attachedMob.manager.getAllIDs()){
            // Check that the mobDict actually contains that mob ID
            if (manager.mobDict.ContainsKey(uniqueID)){

                BaseMob otherMob = manager.mobDict[uniqueID];
                
                // Check if the otherMob is a predator for a given class
                if (otherMob.mobType == predatorType){
                    // Distance to predator
                    double distance = Vector2.Distance(attachedMob.rigidBody.position, otherMob.rigidBody.position);
                    
                    if (distance < predatorKillRadius){
                        attachedMob.OnDeath();
                        manager.UnRegisterMob(attachedMob);
                        return;
                    }
                }

            } else {
                Debug.Log("uniqueID not in list: " + uniqueID.ToString());
            }
        }
    }
    
    // Retrieve closest food
    public virtual (Vector2?, int?) getClosestFood(int foodType){

        double minFoodDistance = double.MaxValue;
        Vector2 closestFoodPosition = Vector2.zero;
        int closestFoodID = -1; // Set initial closestFoodID to -1 (invalid, all IDs are chosen positive in the manager)
        MobManager manager = attachedMob.manager;

        // Loop over all entities to find closest food
        foreach (int uniqueID in attachedMob.manager.getAllIDs()){
            // Check that the mobDict actually contains that mob ID
            if (manager.mobDict.ContainsKey(uniqueID)){

                BaseMob otherMob = manager.mobDict[uniqueID];

                // Check if the otherMob is food
                if (otherMob.mobType == foodType){
                    // Distance to food item
                    double distance = Vector2.Distance(attachedMob.rigidBody.position, otherMob.rigidBody.position);
                    // If distance is closer than the last distance saved, update the closest distance and ID
                    if ((distance < minFoodDistance) & (distance < attachedMob.getSeekingFoodRadius())){
                        minFoodDistance = distance;
                        closestFoodID = uniqueID;
                        closestFoodPosition = otherMob.rigidBody.position;
                    }
                }

            } else {
                Debug.Log("uniqueID not in list: " + uniqueID.ToString());
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
        
        float maxAngle = 0.1f;

        if (_oldDirection == new Vector2(0, 0) || _nextDirection == new Vector2(0, 0)){
            _oldDirection = new Vector2(Random.Range(-1f, 1f), (Random.Range(-1f, 1f))).normalized;
            _nextDirection = new Vector2(Random.Range(-1f, 1f), (Random.Range(-1f, 1f))).normalized;
        }

        if (_currentSteps == interpolatingSteps){
            _oldDirection = _nextDirection;
            attachedMob.rigidBody.velocity = _nextDirection * (attachedMob.getMobSpeed());

            //_nextDirection = _oldDirection.Rotate(Random.Range(-maxAngle, maxAngle));
            _nextDirection.x = Random.Range(-1f,1f);
            _nextDirection.y = Random.Range(-1f,1f);
            _nextDirection = _nextDirection.normalized;

            _currentSteps = 0;
        }
        else{
            _movementDirection = Vector2.Lerp(_oldDirection, _nextDirection, (float)_currentSteps / interpolatingSteps).normalized;
            attachedMob.rigidBody.velocity = _movementDirection * (attachedMob.getMobSpeed());

            _currentSteps += 1;
        }
    }

    // Move function, default to random walk
    public abstract void Move();
}
