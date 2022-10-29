using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    public bool CreateTower(Tower tower, Vector3 position)
    {
        Bank bank = FindObjectOfType<Bank>();
        if(bank == null)
        {
            return false;
        }

        if(bank.CurrentBalance >= bank.cost)
        {
        Instantiate(tower.gameObject, position, Quaternion.identity);
        bank.classTorE = true;
        bank.Withdraw(bank.cost);
        return true;
        }

        return false;
    }
}
