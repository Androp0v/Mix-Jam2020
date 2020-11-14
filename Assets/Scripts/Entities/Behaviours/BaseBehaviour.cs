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

    protected void randomWalk(Rigidbody2D _rigidBody)
    {
        // Random walking

        if (attachedMob.oldDirection == new Vector2(0, 0) || attachedMob.nextDirection == new Vector2(0, 0))
        {
            attachedMob.oldDirection = new Vector2(Random.Range(-1f, 1f), (Random.Range(-1f, 1f))).normalized;
            attachedMob.nextDirection = new Vector2(Random.Range(-1f, 1f), (Random.Range(-1f, 1f))).normalized;
        }

        /*if (_currentSteps == interpolatingSteps)
        {
            _oldDirection = _nextDirection;
            _rigidBody.velocity = _nextDirection * (idlingSpeed * Time.deltaTime);

            _nextDirection = _oldDirection.Rotate(Random.Range(-maxAngle, maxAngle));

            _currentSteps = 0;
        }
        else
        {
            _movementDirection = Vector2.Lerp(_oldDirection, _nextDirection, (float)_currentSteps / interpolatingSteps).normalized;
            _rigidBody.velocity = _movementDirection * (idlingSpeed * Time.deltaTime);

            _currentSteps += 1;
        }*/
    }

    public virtual void Move(Rigidbody2D rigidBody){
        randomWalk(rigidBody);
    }
}
