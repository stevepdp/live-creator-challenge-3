using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public static event Action OnWalletChange;
    public static event Action OnPlayerCantAffordIt;
    public static event Action OnPlayerBoughtItem;

    [SerializeField] int gold;
    [SerializeField] int minGold;
    [SerializeField] int maxGold;
    [SerializeField] Basket basket;
    [SerializeField] Item itemScriptableObject;

    public int Gold
    {
        get { return gold; }
        set { gold = value; }
    }

    public Item ItemConsideration
    {
        get { return itemScriptableObject;  }
        set { itemScriptableObject = value;  }
    }

    void OnEnable()
    {
        ItemCard.OnPlayerItemConsideration += UpdateSelection;
    }


    void OnDisable()
    {
        ItemCard.OnPlayerItemConsideration -= UpdateSelection;
    }

    void Awake()
    {
        SetWalletDefaults();
    }

    public void Buy()
    {
        if (itemScriptableObject != null)
        {
            // can I afford it?
            if (itemScriptableObject.cost - gold < minGold)
            {
                gold -= itemScriptableObject.cost;
                itemScriptableObject.backpackStatus = true;
                OnWalletChange?.Invoke();
                OnPlayerBoughtItem?.Invoke();
            }
            else
            {
                OnPlayerCantAffordIt?.Invoke();
            }
        }       
    }

    void SetWalletDefaults()
    {
        gold = maxGold;
        OnWalletChange?.Invoke();
    }

    void UpdateSelection()
    {
        if (basket != null)
            itemScriptableObject = basket.Item;
    }
}
