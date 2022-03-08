using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EItemType
{
    None,
    Weapon,
    SubWeqpon,
    Portion
}

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]
public class Item : ScriptableObject
{
    public EItemType iType;
    public Sprite itemImage;
    public int itemPrice;
    public string itemInfo;

    public float hp;
    public float atk;
}
