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
    GameObject deposit0;
    GameObject deposit1;
    GameObject deposit2;
    GameObject deposit3;
    GameObject deposit4;
    GameObject[] deposits;
    GameObject withdraw0;
    GameObject withdraw1;
    GameObject withdraw2;
    GameObject withdraw3;
    GameObject withdraw4;
    GameObject[] withdraws;

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
        deposit0 = canvas.transform.GetChild(3).GetChild(0).gameObject;
        deposit1 = canvas.transform.GetChild(3).GetChild(1).gameObject;
        deposit2 = canvas.transform.GetChild(3).GetChild(2).gameObject;
        deposit3 = canvas.transform.GetChild(3).GetChild(3).gameObject;
        deposit4 = canvas.transform.GetChild(3).GetChild(4).gameObject;
        deposits = new GameObject[] 
        {deposit0, deposit1, deposit2, deposit3, deposit4};
        withdraw0 = canvas.transform.GetChild(3).GetChild(5).gameObject;
        withdraw1 = canvas.transform.GetChild(3).GetChild(6).gameObject;
        withdraw2 = canvas.transform.GetChild(3).GetChild(7).gameObject;
        withdraw3 = canvas.transform.GetChild(3).GetChild(8).gameObject;
        withdraw4 = canvas.transform.GetChild(3).GetChild(9).gameObject;
        withdraws = new GameObject[] 
        {withdraw0, withdraw1, withdraw2, withdraw3, withdraw4};
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
