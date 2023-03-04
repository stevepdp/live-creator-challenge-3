using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    [SerializeField] Item itemScriptableObject;
    [SerializeField] Wallet wallet;

    public Item Item
    {
        get { return itemScriptableObject; }
        set { itemScriptableObject = value; }
    }
}
