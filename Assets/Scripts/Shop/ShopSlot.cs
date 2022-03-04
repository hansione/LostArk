using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopSlot : MonoBehaviour, IPointerClickHandler
{
    public Item item;

    public Image itemImage;
    public Text textPrice;
    public Text itemInfo;

    public BuyList buyList;

    public void OnPointerClick(PointerEventData eventData)
    {
        buyList.Add(gameObject.GetComponent<ShopSlot>().item);
    }

    // Start is called before the first frame update
    void Start()
    {
        textPrice.text = item.itemPrice.ToString();
        itemImage.sprite = item.itemImage;
        itemInfo.text = item.itemInfo;
    }

}
