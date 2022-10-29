using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextPool : MonoBehaviour
{
public GameObject textOne;
    void Start() 
    {
        textOne = this.gameObject.transform.GetChild(0).gameObject;
    }

    public void ShowDepositText()
    {
        textOne.SetActive(true);
        Debug.Log("Ausgeführt");
    }
}