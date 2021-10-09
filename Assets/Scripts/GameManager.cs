using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject boxPrefab = null;
    public float minX, minY, maxX, maxY;
    public int minQty, maxQty;

    // Start is called before the first frame update
    void Start()
    {
        int random = Random.Range(minQty, maxQty);
        while (random != 0)
        {
            Instantiate(boxPrefab, new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY)), Quaternion.identity);
            random--;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
