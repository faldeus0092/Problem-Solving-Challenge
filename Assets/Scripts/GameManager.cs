using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region singleton
    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }
    
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion

    [SerializeField]
    private GameObject boxPrefab = null;
    [SerializeField]
    public float minX = -7f, minY = -4.8f, maxX = 7f, maxY = -4.8f;
    public int minQty, maxQty;

    [SerializeField]
    private GameObject ball = null;

    public bool IsGameOver { get { return isGameOver; } }
    private bool isGameOver = false;


    // Start is called before the first frame update
    private void Start()
    {
        isGameOver = false;
        int random = Random.Range(minQty, maxQty);
        while (random != 0)
        {
            Instantiate(boxPrefab, new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY)), Quaternion.identity);
            //SpawnBox();
            random--;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && isGameOver)
        {
            Scene scene = SceneManager.GetActiveScene();

            switch (scene.name)
            {
                case "9":
                    SceneManager.LoadScene("9");
                    break;
            }
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        if (ScoreManager.score > ScoreManager.highscore)
        {
            ScoreManager.Instance.SetHighScore(ScoreManager.score);
        }
    }

    public void SpawnBox(GameObject box)
    {
        // Debug.Log("hi");
        StartCoroutine(RespawnWithDelay(box));
    }

    IEnumerator RespawnWithDelay(GameObject obj)
    {
        obj.SetActive(false);
        //Debug.Log("Masuk");
        yield return new WaitForSeconds(3);

        bool isSpawned = false;
        while (!isSpawned)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(minX, maxX), 
                                            Random.Range(minY, maxY), 
                                            0f);
            // 1.13 dapat dari radius circle collider + setengah diagonal box collider
            if ((spawnPosition - ball.transform.position).magnitude < 1.13)
            {
                continue;
            }
            else
            {
                obj.transform.position = spawnPosition;
                isSpawned = true;
            }
        }

        obj.SetActive(true);
    }

   
}
