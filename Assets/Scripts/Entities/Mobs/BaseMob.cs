using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class BaseMob : MonoBehaviour
{   
    // CLASS CONSTANTS
    public const double simulationTimestep = 0.1;

    public const int STATIC_FOOD = 0;
    public const int BASE_MOB = 1;
    public const int BUNNY_MOB = 2;
    public const int FOX_MOB = 3;

    // MOB STATS
    [SerializeField]
    public MobManager manager; // Single object that manages all mobs

    private const float maxAge = 300; /// Age until mob dies
    public virtual double getMaxAge(){
        return maxAge;
    }
    
    private const double seekingFoodRadius = 10; // Radius for seeking food
    public double getSeekingFoodRadius(){
        return seekingFoodRadius;
    }

    private float mobSpeed = 1; // Speed at which the mob moves
    public float getMobSpeed(){
        return mobSpeed;
    }

    public const float waitTimeAfterMate = 30;

    // MOB PROPERTIES
    public Rigidbody2D rigidBody;
    public BaseBehaviour behaviour;
    public int managerID;
    public int mobType = BASE_MOB;

    // MOB STATUS
    private int _hunger = 20;
    private int _matingUrge = 10;
    private double _age = 0;
    public double timeSinceLastMating = double.MaxValue;

    public bool wantsToMate(){
        if (timeSinceLastMating > waitTimeAfterMate){
            return true;
        } else {
            return false;
        }
    }

    // Specific subclass Start is overriden in subclasses
    public abstract void StartSpecific();

    // Start is called before the first frame update (setup mob here)
    void Start()
    {
        // Set the age to zero
        _age = 0.0;
        // Initialize the rigidBody
        //rigidBody = GameObject.AddComponent<Rigidbody2D>();
        // Register mob in manager
        Debug.Log("REGISTERED MOB");
        manager.RegisterMob(this);
        // Call specific start on subclasses
        StartSpecific();
    }

    // Update is called once per frame
    void Update()
    {
        // Update age of the mob on every update
        _age += simulationTimestep;
        // Check if the mob is too old
        if (_age > getMaxAge()) {
            OnDeath();
        }
        timeSinceLastMating += simulationTimestep;
        // Move the mob
        behaviour.Move();

    }

    // OnDeath is called when the mob dies
    public void OnDeath(){
        manager.UnRegisterMob(this);
        rigidBody.simulated = false;
        rigidBody.velocity = Vector2.zero;
        this.gameObject.SetActive(false);
        Destroy(transform.gameObject);
    }

}