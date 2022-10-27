using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;

    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }

    void OnMouseDown() 
    {
        if(isPlaceable)
        {
        bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
        if (isPlaced)
        {
            Destroy(transform.GetChild(3).gameObject);
        }
        isPlaceable = !isPlaced;
        }
    }
}
