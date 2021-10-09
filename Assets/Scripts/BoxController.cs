using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoxController : MonoBehaviour
{
    GameObject player;
    GameObject gameManager;
    GameManager gameManagerScript;

    void Awake()
    {
        // get gameobject player
        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
    }

    // callback jika ada yang masuk trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player && other.isTrigger == false)
        {
            // increment score
            ScoreManager.score++;

            // panggil method spawn box
            Scene scene = SceneManager.GetActiveScene();
            switch (scene.name)
            {
                case "7":
                    Destroy(gameObject);
                    break;
                case "8":
                    gameManagerScript.SpawnBox(gameObject);
                    break;
            }
            
        }
    }
    
}
