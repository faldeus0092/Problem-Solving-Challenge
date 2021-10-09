using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByMousePointer : MonoBehaviour
{
    private Vector3 mousePosition;
    private float moveSpeed = 10f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        if(transform.position != mousePosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, mousePosition, Time.deltaTime * moveSpeed);
        }
        
    }
}
