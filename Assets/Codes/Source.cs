using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Source : MonoBehaviour
{
    [SerializeField] int startMoney = 100;

    [SerializeField] int currentMoney ;

    public int CurrentMoney {  get { return currentMoney; } }

    [SerializeField] TextMeshProUGUI displaySource;

    void Awake()
    {
        currentMoney = startMoney;
        UpdateDisplay();
    }

    public void IncreaseMoney(int amount)
    {
        UpdateDisplay();
        currentMoney += Mathf.Abs(amount);
    }

    public void DecreaseMoney(int amount)
    {
        currentMoney -= Mathf.Abs(amount);
        UpdateDisplay();
        if (currentMoney < 0)
        {
            ReloadScene();
        }
    }

    void UpdateDisplay() 
    {
        displaySource.text = "Money:" + currentMoney;
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
