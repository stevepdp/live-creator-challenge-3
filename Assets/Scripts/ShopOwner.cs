using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopOwner : MonoBehaviour
{
    [SerializeField] TMP_Text shopOwnerSpeakText;
    [SerializeField] Basket basket;
    [SerializeField] Wallet wallet;

    void Start()
    {
        shopOwnerSpeakText.text = "Welcome!";
    }

    void OnEnable()
    {
        ItemCard.OnPlayerItemConsideration += SpeakItemConsideration;
        Wallet.OnPlayerBoughtItem += SpeakThanks;
        Wallet.OnPlayerCantAffordIt += SpeakPlayerCantAfford;
    }

    void OnDisable()
    {
        ItemCard.OnPlayerItemConsideration -= SpeakItemConsideration;
        Wallet.OnPlayerBoughtItem += SpeakThanks;
        Wallet.OnPlayerCantAffordIt += SpeakPlayerCantAfford;
    }

    IEnumerator ClearDialog()
    {
        yield return new WaitForSeconds(3);
        shopOwnerSpeakText.text = "";
    }

    void SpeakItemConsideration()
    {
        shopOwnerSpeakText.text = "Considering the " + basket?.Item.name + "?";
    }

    void SpeakPlayerCantAfford()
    {
        shopOwnerSpeakText.text = "Sorry...you can't afford it. You have only " + wallet?.Gold + " gold";
    }

    void SpeakThanks()
    {
        shopOwnerSpeakText.text = "Thanks! Enjoy the " + basket?.Item.name + ".";
        //StartCoroutine(ClearDialog());
    }
}
