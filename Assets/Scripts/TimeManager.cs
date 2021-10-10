using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    #region singleton
    private static TimeManager _instance;

    public static TimeManager Instance { get { return _instance; } }

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
    private float timeLimit = 20;

    public Text timeText;
    
    private float timer;

    // Start is called before the first frame update
    private void Start()
    {
        timeText = GetComponent<Text>();
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsGameOver)
            return;
        if(timer > timeLimit)
        {
            GameManager.Instance.GameOver();
            return;
        }
        timer += Time.deltaTime;
        if (timer <= 0)
        {
            timer = 0.0f;
            timeText.text = "Time left: 0";
        }
        else
        {
            timeText.text = "Time left: " + Mathf.Round((timeLimit - timer) * 100f) / 100f;
        }
        
    }
    
}
