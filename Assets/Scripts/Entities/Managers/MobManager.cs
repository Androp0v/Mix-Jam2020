using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobManager : MonoBehaviour
{

    // MOB MANAGER PROPERTIES
    public Dictionary<int, BaseMob> mobDict = new Dictionary<int, BaseMob>();
    public Dictionary<(int,int), double> distanceDict = new Dictionary<(int,int), double>();
    public List<int> allIDs = new List<int>();
    
    // Private properties
    private int _mobCount = 0;
    private int _nextID = 0;

    // Public functions to modify MobController list

    public void RegisterMob(BaseMob newMob)
    {   
        // Add mob to the list
        mobDict[_nextID] = newMob;
        newMob.managerID = _nextID;
        allIDs.Add(_nextID);
        // Increment the _nextID used value (works as a primaary autoincrement key)
        _nextID += 1;
    }

    public void UnRegisterMob(BaseMob deadMob)
    {
        // Remove mob and ID from the lists
        mobDict.Remove(deadMob.managerID);
        allIDs.Remove(deadMob.managerID);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Reset the direction and distance dictionaries
        distanceDict = new Dictionary<(int, int), double>();

        for (int i = 0; i < allIDs.Count; i++) {
            for (int j = i; j < allIDs.Count - i; j++) {

                // Compute the direction between mobs
                double distance = new Vector2(mobDict[allIDs[j]].rigidBody.position.x - mobDict[allIDs[i]].rigidBody.position.x,
                                              mobDict[allIDs[j]].rigidBody.position.y - mobDict[allIDs[i]].rigidBody.position.y)
                                    .magnitude;

                // Save the distances
                distanceDict[(allIDs[i], allIDs[j])] = distance;
                distanceDict[(allIDs[j], allIDs[i])] = distance;
                
            }
        }
        
    }
}
