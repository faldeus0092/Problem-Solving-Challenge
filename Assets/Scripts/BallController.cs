using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    // 1-2
    public float xInitialForce;
    public float yInitialForce;

    private Rigidbody2D rigidBody2D;

    string curScene;

    // WASD move keys
    public KeyCode upButton = KeyCode.W;
    public KeyCode downButton = KeyCode.S;
    public KeyCode rightButton = KeyCode.D;
    public KeyCode leftButton = KeyCode.A;
    public float speed = 19.0f;

    // Start is called before the first frame update
    private void Start()
    {       
        Scene scene = SceneManager.GetActiveScene();
        curScene = scene.name;

        // atur behavior bola tergantung jenis scene
        switch (curScene)
        {
            case "1":
                break;
            case "2":
                rigidBody2D = GetComponent<Rigidbody2D>();
                yeetBallRandomly();
                break;
            case "3":
                rigidBody2D = GetComponent<Rigidbody2D>();
                yeetBallRandomly();
                break;
            case "4":
                rigidBody2D = GetComponent<Rigidbody2D>();
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // atur behavior bola tergantung jenis scene
        switch (curScene)
        {
            case "1":
                break;
            case "2":
                break;
            case "3":
                break;
            case "4":
                controlBall();
                break;
        }
    }

    private void controlBall()
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

    private void yeetBallRandomly()
    {
        // kodingan dari game pong
        // Gaya komponen Y random
        float yRandomInitialForce = UnityEngine.Random.Range(-yInitialForce, yInitialForce);

        // Arah kiri/kanan secara random
        float randomDirection = UnityEngine.Random.Range(0, 2);
        
        // Menggunakan Phytagoras agar kecepatannya konstan
        float ballSpeed = yInitialForce * yInitialForce;
        xInitialForce = Mathf.Sqrt(ballSpeed - (yRandomInitialForce * yRandomInitialForce));
        
        if (randomDirection < 1.0f)
        {
            rigidBody2D.AddForce(new Vector2(-xInitialForce, yRandomInitialForce));
        }
        else 
        {
            rigidBody2D.AddForce(new Vector2(xInitialForce, yRandomInitialForce));
        }
    }

    
}
