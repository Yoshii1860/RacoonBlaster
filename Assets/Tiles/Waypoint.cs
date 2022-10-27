using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] GameObject cannonPrefab;

    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }

    void OnMouseDown() 
    {
        if(isPlaceable)
        {
        Destroy(transform.GetChild(3).gameObject);
        Instantiate(cannonPrefab, transform.position, Quaternion.identity);
        isPlaceable = false;
        }
    }
}
