using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType
{
    Heart,
    Mana,
    Bow,
    Arrows,
    Sword,
    Shield,
    Armour,
    Tunic
}

[CreateAssetMenu(fileName = "NewItem", menuName = "Shop/Add Item", order = 0)]
public class Item : ScriptableObject
{
    public ItemType itemType;
    public new string name;
    public int cost;
    public Color color; // tmp representation
    public Image image; // ...later
    public bool backpackStatus;
}
