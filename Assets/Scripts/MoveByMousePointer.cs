using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "5")
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            if (transform.position != mousePosition)
            {
                transform.position = Vector2.MoveTowards(transform.position, mousePosition, Time.deltaTime * moveSpeed);
            }
        }
        else
        {
            if (!GameManager.Instance.IsGameOver)
            {
                mousePosition = Input.mousePosition;
                mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

                if (transform.position != mousePosition)
                {
                    transform.position = Vector2.MoveTowards(transform.position, mousePosition, Time.deltaTime * moveSpeed);
                }
            }
        }
    }
}
