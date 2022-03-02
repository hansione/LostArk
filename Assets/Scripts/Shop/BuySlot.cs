using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuySlot : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        BuyList bl = gameObject.GetComponentInParent<BuyList>();
        bl.Remove(name);
    }
}
