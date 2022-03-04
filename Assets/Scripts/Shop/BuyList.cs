using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyList : MonoBehaviour
{
    [SerializeField]
    List<Item> buySlots = new List<Item>();
    public Image[] buySlotImage;

    // Update is called once per frame
    void Update()
    {
        buy();
    }

    void buy()
    {
        if (buySlots.Count.Equals(0)) return;

        for (int i = 0; i < buySlots.Count; i++)
        {
            if (buySlots[i] == null)
            {
                break;
            }

            buySlotImage[i].sprite = buySlots[i].itemImage;
        }
    }

    public void Add(Item item)
    {
        if (buySlots.Count >= buySlotImage.Length) return;

        buySlots.Add(item);
    }

    public void Remove(string imageName)
    {
        for (int i = 0; i < buySlots.Count; i++)
        {
            if(buySlotImage[i].name.Equals(imageName))
            {
                buySlots.RemoveAt(i);
                buySlotImage[i].sprite = null;
            }

        }

        // 앞으로 땡기기
        for (int i = buySlots.Count; i < buySlotImage.Length; i++)
        {
            buySlotImage[i].sprite = null;
        }
    }

    // 구매 버튼
    public void BuyButton()
    {
        for(int i = 0; i < buySlots.Count; i++)
        {
            Inven.Instance.Add(buySlots[i]);
            Inven.Instance.Money -= buySlots[i].itemPrice;
        }

        buySlots.Clear();
        for(int i = 0; i < buySlotImage.Length; i++)
        {
            buySlotImage[i].sprite = null;
        }
    }

    
}
