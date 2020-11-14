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
    
    // Random Walk function (idle)
    protected void randomWalk(Rigidbody2D _rigidBody){
        // TO-DO RANDOM WALK HERE
    }

    // Move function, default to random walk
    public virtual void Move(Rigidbody2D rigidBody){
        randomWalk(rigidBody);
    }
}
