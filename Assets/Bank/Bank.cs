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

    [SerializeField] GameObject[] deposits;
    [SerializeField] GameObject[] withdraws;

    [SerializeField] [Range(0.1f, 10f)] float restartTimer = 3f;

    [SerializeField] TextMeshProUGUI displayBalance;
    [SerializeField] public int cost = 50;
    [SerializeField] public int goldPenalty = 25;

    public bool classTorE = false;

    //string costTower;

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

    void DisplayDepositText()
    {
        StartCoroutine(ToggleDepositText());
    }

    IEnumerator ToggleDepositText()
     {
         foreach(GameObject deposit in deposits)
         {
            if(deposit.activeSelf == false)
            {   
                deposit.SetActive(true);
                yield return new WaitForSeconds(2f);
                deposit.SetActive(false);
                break;
            }
        }
    }

    void DisplayWithdrawText()
    {
        StartCoroutine(ToggleWithdrawText());
    }

    IEnumerator ToggleWithdrawText()
     {
         foreach(GameObject withdraw in withdraws)
         {
            if(withdraw.activeSelf == false)
            {
                if(classTorE != false)
                {
                    withdraw.GetComponent<TextMeshProUGUI>().text = "-" + cost.ToString(); 
                }
                else
                {
                    withdraw.GetComponent<TextMeshProUGUI>().text = "-" + goldPenalty.ToString();
                }
                withdraw.SetActive(true);
                yield return new WaitForSeconds(2f);
                withdraw.SetActive(false);
                break;
            }
        }
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        DisplayDepositText();
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
        DisplayWithdrawText();
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
