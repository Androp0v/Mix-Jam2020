using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticFoodBehaviour : BaseBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        
    }

    // Move function, default to random walk
    override public void Move(){
        checkPredatorTooClose(BaseMob.BUNNY_MOB);
    }
}
