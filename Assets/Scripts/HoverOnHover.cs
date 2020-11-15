using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverOnHover : MonoBehaviour
{
    public GameObject movableObject;

    void OnMouseEnter()
    {
        movableObject.transform.Translate(Vector2.up);
        Debug.Log("HOVER");
    }
    void OnMouseExit()
    {
        movableObject.transform.Translate(Vector2.down);
    }
}
