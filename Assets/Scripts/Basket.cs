using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    [SerializeField] int selection;
    [SerializeField] Wallet wallet;

    public int Selection
    {
        get { return selection; }
        set { selection = value; }
    }

    void OnEnable()
    {
        ItemCard.OnPlayerItemConsideration += LogSelection;
    }

    void OnDisable()
    {
        ItemCard.OnPlayerItemConsideration -= LogSelection;
    }

    void LogSelection()
    {
        Debug.Log(selection);
    }
}
