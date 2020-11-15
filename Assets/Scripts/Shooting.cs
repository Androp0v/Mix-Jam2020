using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public float shootingRate = 1f;
    public float bulletSpeed = 1f;
    float startTime;

    List<GameObject> targets;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<BaseMob>() != null)
        { targets.Add(other.gameObject); }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        targets.Remove(other.gameObject);
    }


    void Start()
    {
        startTime = Time.time;
        targets = new List<GameObject>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Time.time-startTime > shootingRate)
        {
            startTime = Time.time;
            Shoot(targets, bullet, bulletSpeed);
        }
    }

    void Shoot(List<GameObject> targets, GameObject bullet, float bulletSpeed)
    {
        GameObject target = targets[Random.Range(0, targets.Count)];
        {
            Vector2 direction;
            GameObject newBullet;
            direction = target.transform.position - transform.position;
            newBullet = Instantiate(bullet, transform);
            newBullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
            newBullet.transform.Rotate(0, 0, Vector2.SignedAngle(Vector2.right, direction)-30f);
        }
    }
}
