using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inven : MonoBehaviour
{
    public static Inven Instance;

    public GameObject invenSymbol;
    public GameObject invenBase;    // �κ��丮 �޹��

    public bool isActived;                 // �κ��丮 ��/Ȱ��ȭ

    public Text moneyText;
    int money;                      // ���� ���� ��

    public Slot[] invenSlots;

    public bool isShopUse = false;
    public bool isEquipUse = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        invenSlots = invenBase.GetComponentsInChildren<Slot>();

        money = 1000;
        moneyText.text = money.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isActived = !isActived;
            invenBase.SetActive(isActived);
        }

        invenSymbol.SetActive(invenBase.activeSelf);
    }

    public void Add(Item item)
    {
        if(money <= 0)
        {
            money = 0;
            return;
        }

        for(int i = 0; i < invenSlots.Length; i++)
        {
            if(invenSlots[i].item == null)
            {
                invenSlots[i].Add(item);
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
