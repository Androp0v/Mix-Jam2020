using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public string selectedTower;

    public void ChangeSelectedTower(string towerName)
    {
        selectedTower = towerName;
    }
}
