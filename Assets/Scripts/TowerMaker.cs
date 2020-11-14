using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMaker : MonoBehaviour
{
    public GameController gameController;
    public GameObject notower;
    public GameObject eiffel;
    public GameObject khalifa;
    GameObject towerToCreate;
    GameObject createdTower;

    void Start()
    {
        towerToCreate = notower;
        createdTower = Instantiate(towerToCreate, gameObject.transform);
    }
    void OnMouseDown()
    {
        if (gameController.selectedTower == "Eiffel")
        {
            towerToCreate = eiffel;
        }
        else if (gameController.selectedTower == "Khalifa")
        {
            towerToCreate = khalifa;
        }
        if (gameController.selectedTower == "Erase")
        {
            towerToCreate = notower;
        }

        Destroy(createdTower);
        createdTower = Instantiate(towerToCreate, gameObject.transform);
    }
}
