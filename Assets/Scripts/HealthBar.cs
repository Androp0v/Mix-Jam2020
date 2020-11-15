using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public GameController gameController;
    public GameObject cherry;
    GameObject lastCherry;

    void Update()
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < (int)gameController.life; i++)
        {
            Instantiate(cherry, gameObject.transform);
        }

        lastCherry = Instantiate(cherry, gameObject.transform);
        lastCherry.GetComponent<Image>().color = new Color(1, 1, 1, gameController.life - (int)gameController.life);
    }

}
