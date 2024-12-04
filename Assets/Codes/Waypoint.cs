using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] DefenceCost defensePrefab;
    [SerializeField] DefenceCost defensePrefab1;
    [SerializeField] DefenceCost defensePrefab2;
    [SerializeField] bool isAvailable;

    public bool IsAvailable
    {  
        get 
        { 
            return isAvailable; 
        } 
    }
    void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            bool isFull = defensePrefab.CreateDefense(defensePrefab, transform.position);
            isAvailable = !isFull;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            bool isFull = defensePrefab1.CreateDefense(defensePrefab1, transform.position);
            isAvailable = !isFull;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            bool isFull = defensePrefab2.CreateDefense(defensePrefab2, transform.position);
            isAvailable = !isFull;
        }
    }

}
