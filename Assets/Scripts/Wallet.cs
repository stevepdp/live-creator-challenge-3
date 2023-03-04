using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public static event Action OnWalletChange;

    [SerializeField] int gold;
    [SerializeField] int minGold;
    [SerializeField] int maxGold;

    void Awake()
    {
        SetWalletDefaults();
    }

    public int Gold
    {
        get { return gold; }
        set { gold = value; }
    }

    void SetWalletDefaults()
    {
        gold = maxGold;
        OnWalletChange?.Invoke();
    }
}
