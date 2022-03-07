using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IBeginDragHandler, IDragHandler, IDropHandler, IEndDragHandler, IPointerClickHandler
{
    // ĸ��ȭ
    public Item item;

    public Image itemImage;
    public Text textCount;
    public int itemCount = 0;

    public Container container;

    public EItemType slotType;

    private void Start()
    {
        container = GameObject.Find("Container").GetComponent<Container>();
    }

    // ������ �̹����� ���� ���� (������ ����� ��)
    // private method camelCase
    private void SetAlpha(float alpha)
    {
        Color color = itemImage.color;      // ������ �ٲ��� (������ �ƴ϶� ���� ���� �� �� ����)
        color.a = alpha;                    // �� ���� ��
        itemImage.color = color;            // ���� �� ����
    }

    // ���Կ� ������ �߰�
    public void Add(Item addItem, int count = 1)
    {
        item = addItem;
        itemImage.sprite = addItem.itemImage;
        itemCount = count;

        if (item.iType.Equals(EItemType.Weapon))
        {
            textCount.text = itemCount.ToString();
        }

        SetAlpha(1);
    }

    // �ִٸ� ���� ����
    void setCount(int count)
    {
        itemCount += count;
        textCount.text = itemCount.ToString();

        if (itemCount <= 0)
        {
            removeItem();
        }        
    }

    void removeItem()
    {
        item = null;
        itemImage.sprite = null;
        itemCount = 0;
        textCount.text = "";
        SetAlpha(0);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (item == null)
        {
            return;
        }

        itemImage.gameObject.SetActive(false);
        container.gameObject.SetActive(true);

        container.isDrag = true;
        container.item = item;
        container.img.sprite = itemImage.sprite;
        container.itemCount = itemCount;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(!container.isDrag)
        {
            return;
        }

        container.transform.position = eventData.position;
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (!container.isDrag)
        {
            return;
        }

        if (item != null)
        {
            if (slotType.Equals(EItemType.None) ||
                slotType.Equals(container.item.iType))
            {
                Item tempItem = item;
                item = container.item;
                container.item = tempItem;

                Sprite tempSprite = itemImage.sprite;
                itemImage.sprite = container.img.sprite;
                container.img.sprite = tempSprite;

                int tempCount = itemCount;
                itemCount = container.itemCount;
                container.itemCount = tempCount;
            }
            
        }
        else
        {
            if(slotType.Equals(EItemType.None) ||
               slotType.Equals(container.item.iType))
            {
                item = container.item;
                itemImage.sprite = container.img.sprite;
                itemCount = container.itemCount;
                SetAlpha(1);

                container.isDrag = false;
            }
        }

        container.isEquip = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {      

        itemImage.gameObject.SetActive(true);

        if (item == container.item)
        {
            if (!container.isDrag) removeItem();
        }
        else
        {
            Add(container.item, container.itemCount);
        }


        container.isDrag = false;
        container.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(Inven.Instance.isShopUse)
        {
            Inven.Instance.Money += item.itemPrice;
            removeItem();
        }
    }
}
