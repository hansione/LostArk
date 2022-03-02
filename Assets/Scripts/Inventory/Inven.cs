using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inven : MonoBehaviour
{
    public static Inven Instance;

    public GameObject invenBase;    // 인벤토리 뒷배경

    bool isActived;               // 인벤토리 비/활성화

    public Text moneyText;
    int money;             // 현재 가진 돈

    public Slot[] slots;

    public bool isShopUse = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        slots = invenBase.GetComponentsInChildren<Slot>();

        money = 1000;
        moneyText.text = money.ToString();
    }

    private void Update()
    {
        ActiveInventory();
    }

    void ActiveInventory()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            // 변수명 더 명확하게
            isActived = !isActived;

            if (isActived)
            {
                openInventory();
            }
            else
            {
                closeInventory();
            }
        }

    }

    void openInventory()
    {
        invenBase.SetActive(true);
    }

    void closeInventory()
    {
        invenBase.SetActive(false);
    }

    public void Add(Item item)
    {
        if(money <= 0)
        {
            return;
        }

        for(int i = 0; i < slots.Length; i++)
        {
            if(slots[i].item == null)
            {
                slots[i].Add(item);
                break;
            }
        }
    }

    public int Money
    {
        get
        {
            return money;
        }
        set
        {
            money = value;
            moneyText.text = money.ToString();
        }
    }

}
