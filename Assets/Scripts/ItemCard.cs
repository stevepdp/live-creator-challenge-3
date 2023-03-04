using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemCard : MonoBehaviour, ISelectHandler
{
    public static event Action OnPlayerItemConsideration;

    [SerializeField] TMP_Text displayNameText;
    [SerializeField] Image displayImage;
    [SerializeField] TMP_Text displayCostText;
    [SerializeField] TMP_Text displayBackpackStatusText;
    [SerializeField] Item itemScriptableObject;
    [SerializeField] Basket basket;

    new string name;
    Image image;
    Color colourFallback;
    int cost;
    ItemType itemType;
    bool inBackpack;

    void Awake()
    {
        displayImage = displayImage.GetComponent<Image>();
        SetCard();
    }
        
    void Start() => ShowCard();

    public void OnSelect(BaseEventData eventData)
    {
        if (basket != null) basket.Item = itemScriptableObject;
        OnPlayerItemConsideration?.Invoke();
    }

    void SetCard()
    {
        name = itemScriptableObject?.name;
        image = itemScriptableObject?.image;
        colourFallback = (Color) itemScriptableObject?.color;
        cost = (int) itemScriptableObject?.cost | 0;
        itemType = (ItemType) itemScriptableObject?.itemType;
        inBackpack = (bool) itemScriptableObject?.backpackStatus;
    }

    void ShowCard()
    {
        if (displayNameText != null)
            displayNameText.text = name;

        if (!displayImage.sprite)
        {
            // use colour fallback and set alpha to max
            displayImage.color = (Color) itemScriptableObject.color;
            var tmpColour = displayImage.color;
            tmpColour.a = 1f;
            displayImage.color = tmpColour;
        }

        if (displayCostText != null)
            displayCostText.text = cost.ToString();

        if (displayBackpackStatusText != null)
            displayBackpackStatusText.text = inBackpack ? "B" : "";
    }
}
