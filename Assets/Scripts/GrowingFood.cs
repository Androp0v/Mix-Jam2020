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
    float stepTime = 1f;
    float startTime;

    public GameObject foodMob;



    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startTime = Time.time;
        spriteList = new Sprite[] { step1, step2, step3, step4 };
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
            Instantiate(foodMob).transform.position = transform.position;
            Destroy(gameObject);
        }
    }


}
