using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.EventSystems;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]
public class Item : ScriptableObject
{
    public enum EItemType
    {
        Weapon,
        Portion
    }


    public EItemType iType;
    public Sprite itemImage;
    public int itemPrice;

    
}
