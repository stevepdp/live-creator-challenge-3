using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WalletHUD : MonoBehaviour
{
    [SerializeField] Wallet wallet;
    TMP_Text walletValueText;

    void Awake()
    {
        walletValueText = GetComponent<TMP_Text>();
    }

    void OnEnable()
    {
        Wallet.OnWalletChange += UpdateWalletText;
    }

    void OnDisable()
    {
        Wallet.OnWalletChange -= UpdateWalletText;
    }

    void UpdateWalletText()
    {
        if (walletValueText != null) walletValueText.text = "¥" + wallet?.Gold.ToString();
    }
}
