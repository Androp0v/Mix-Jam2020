using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingFood : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    public Sprite step1;
    public Sprite step2;
    public Sprite step3;
    public Sprite step4;
    Sprite[] spriteList;

    int step = 0;
    float stepTime;
    float startTime;

    public GameObject foodMob;
    public GameObject carrotMob;
    public float carrotProbability = 0.5f;



    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startTime = Time.time;
        spriteList = new Sprite[] { step1, step2, step3, step4 };
        stepTime = Random.Range(2f, 10f);
    }

    void Update()
    {
        if (Time.time - startTime > stepTime)
        {
            startTime = Time.time;
            step++;
        }
        if (step < 4)
        { spriteRenderer.sprite = spriteList[step]; }
        else
        {
            if(Random.Range(0f, 1f) < carrotProbability)
            {
                Instantiate(foodMob).transform.position = transform.position;
            }
            else { Instantiate(carrotMob).transform.position = transform.position; }
            Destroy(gameObject);
        }
    }


}
