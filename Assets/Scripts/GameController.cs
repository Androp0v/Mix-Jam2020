using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public string selectedTower;

    public float life;
    public float lifeSpeed = 0.1f;

    void Start()
    {
        life = 3f;
    }

    void Update()
    {
        life -= lifeSpeed * Time.deltaTime;
    }

    public void ChangeSelectedTower(string towerName)
    {
        selectedTower = towerName;
    }

}