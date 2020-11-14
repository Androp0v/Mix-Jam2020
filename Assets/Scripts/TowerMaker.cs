using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMaker : MonoBehaviour
{
    public GameController gameController;
    public GameObject notower;
    public GameObject tower1;
    GameObject towerToCreate;
    GameObject createdTower;

    void Start()
    {
        towerToCreate = notower;
        createdTower = Instantiate(towerToCreate, gameObject.transform);
    }
    void OnMouseDown()
    {
        if (gameController.selectedTower == "Tower1")
        {
            towerToCreate = tower1;
        }
        if (gameController.selectedTower == "Erase")
        {
            towerToCreate = notower;
        }

        Destroy(createdTower);
        createdTower = Instantiate(towerToCreate, gameObject.transform);
    }
}
