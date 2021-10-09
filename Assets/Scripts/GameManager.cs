using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject boxPrefab = null;
    [SerializeField]
    public float minX = -7f, minY = -4.8f, maxX = 7f, maxY = -4.8f;
    public int minQty, maxQty;

    [SerializeField]
    private GameObject ball = null;

    // Start is called before the first frame update
    void Start()
    {
        int random = Random.Range(minQty, maxQty);
        while (random != 0)
        {
            Instantiate(boxPrefab, new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY)), Quaternion.identity);
            //SpawnBox();
            random--;
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

        yield return new WaitForSeconds(3);

        //Debug.Log("Masuk");
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
