using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    GameObject player;

    void Awake()
    {
        // get gameobject player
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // callback jika ada yang masuk trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player && other.isTrigger == false)
        {
            Destroy(this.gameObject);
            ScoreManager.score++;
        }
    }
}
