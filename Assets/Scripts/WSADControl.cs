using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WSADControl : MonoBehaviour
{
    // WASD move keys
    [SerializeField]
    private KeyCode upButton = KeyCode.W, downButton = KeyCode.S, rightButton = KeyCode.D, leftButton = KeyCode.A;

    [SerializeField]
    private float speed = 19.0f;

    private Rigidbody2D rigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = rigidBody2D.velocity;
        if (Input.GetKey(upButton))
        {
            velocity.y = speed;
        }
        else if (Input.GetKey(downButton))
        {
            velocity.y = -speed;
        }
        else if (Input.GetKey(rightButton))
        {
            velocity.x = speed;
        }
        else if (Input.GetKey(leftButton))
        {
            velocity.x = -speed;
        }
        else
        {
            velocity.y = 0.0f;
            velocity.x = 0.0f;
        }
        rigidBody2D.velocity = velocity;
    }
}
