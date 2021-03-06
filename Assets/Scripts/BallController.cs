using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    // 1-2
    float xInitialForce = 700.0f;
    float yInitialForce = 700.0f;

    // universal
    private Rigidbody2D rigidBody2D;
    string curScene;


    // Start is called before the first frame update
    private void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        curScene = scene.name;

        // atur behavior bola tergantung jenis scene
        switch (curScene)
        {
            case "2":
                rigidBody2D = GetComponent<Rigidbody2D>();
                yeetBallRandomly();
                break;
            case "3":
                rigidBody2D = GetComponent<Rigidbody2D>();
                yeetBallRandomly();
                break;
        }
    }

    // Update is called once per frame
    private void Update()
    {
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
