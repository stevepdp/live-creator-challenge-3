using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Shop/Add Item", order = 0)]
public class Item : ScriptableObject
{
    [SerializeField] ItemType itemType;
    [SerializeField] new string name;
    [SerializeField] int cost;
    [SerializeField] Color color; // tmp representation
    [SerializeField] Sprite icon; // ...later
    
    enum ItemType
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
}
