using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;
    public int CurrentBalance { get { return currentBalance; } }

    GameObject canvas;
    GameObject loseText;
    GameObject winText;

    [SerializeField] [Range(0.1f, 10f)] float restartTimer = 3f;

    [SerializeField] TextMeshProUGUI displayBalance;

    void Awake() {
        {
            currentBalance = startingBalance;
            UpdateDisplay();
        }
    }

    void Start() 
    {
        canvas = GameObject.Find("Canvas");
        loseText = canvas.transform.GetChild(1).gameObject;
        winText = canvas.transform.GetChild(2).gameObject;
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateDisplay();
        if (currentBalance >500)
        {
            if(winText.activeSelf)
            {
                return;
            }
            else
            {
                winText.SetActive(true);
            }

            Invoke("ReloadScene", restartTimer);
        }
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        UpdateDisplay();
        
        if(currentBalance <0)
        {
            if(loseText.activeSelf)
            {
                return;
            }
            else
            {
                loseText.SetActive(true);
            }

            Invoke("ReloadScene", restartTimer);
        }
    }

    void UpdateDisplay()
    {
        displayBalance.text = currentBalance.ToString();
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
