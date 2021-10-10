using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingController : MonoBehaviour
{
    [SerializeField] private Button button1 = null;
    [SerializeField] private Button button2 = null;
    [SerializeField] private Button button3 = null;
    [SerializeField] private Button button4 = null;
    [SerializeField] private Button button5 = null;
    [SerializeField] private Button button6 = null;
    [SerializeField] private Button button7 = null;
    [SerializeField] private Button button8 = null;
    [SerializeField] private Button button9 = null;

    // Start is called before the first frame update
    void Start()
    {
        button1.onClick.AddListener(() =>
        {
            SetButtonInteractable(false);
            SceneManager.LoadScene(1);
        });
        button2.onClick.AddListener(() =>
        {
            SetButtonInteractable(false);
            SceneManager.LoadScene(2);
        });
        button3.onClick.AddListener(() =>
        {
            SetButtonInteractable(false);
            SceneManager.LoadScene(3);
        });
        button4.onClick.AddListener(() =>
        {
            SetButtonInteractable(false);
            SceneManager.LoadScene(4);
        });
        button5.onClick.AddListener(() =>
        {
            SetButtonInteractable(false);
            SceneManager.LoadScene(5);
        });
        button6.onClick.AddListener(() =>
        {
            SetButtonInteractable(false);
            SceneManager.LoadScene(6);
        });
        button7.onClick.AddListener(() =>
        {
            SetButtonInteractable(false);
            SceneManager.LoadScene(7);
        });
        button8.onClick.AddListener(() =>
        {
            SetButtonInteractable(false);
            SceneManager.LoadScene(8);
        });
        button9.onClick.AddListener(() =>
        {
            SetButtonInteractable(false);
            SceneManager.LoadScene(9);
        });
    }

    private void SetButtonInteractable(bool interactable)
    {
        button1.interactable = interactable;
        button2.interactable = interactable;
        button3.interactable = interactable;
        button4.interactable = interactable;
        button5.interactable = interactable;
        button6.interactable = interactable;
        button7.interactable = interactable;
        button8.interactable = interactable;
        button9.interactable = interactable;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
