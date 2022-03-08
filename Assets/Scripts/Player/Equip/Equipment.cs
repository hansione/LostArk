using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Equipment : MonoBehaviour
{
    public Player player;

    public Slot[] equipSlots;

    public GameObject equipBase;
    public GameObject equipSymbol;

    public Text hpText;
    public Text attackText;

    float initHp;
    float addHp;

    float initAttack;
    public float addAttack;

    Container container;

    private void Start()
    {
        container = FindObjectOfType<Container>();
        equipSlots = equipBase.GetComponentsInChildren<Slot>();

        initHp = player.hp;
        initAttack = player.attackDamage;

        addHp = 0;
        addAttack = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Inven.Instance.isEquipUse = !Inven.Instance.isEquipUse;
            equipBase.SetActive(Inven.Instance.isEquipUse);
            equipSymbol.SetActive(Inven.Instance.isEquipUse);
        }

        SetStatus();

        hpText.text = "체력 : " + addHp.ToString("F0");
        attackText.text = "공격력 : " + addAttack.ToString("F0");
    }

    public void SetStatus()
    {
        if (container.isEquip)
        {
            addAttack = 0;
            addHp = 0;

            for (int i = 0; i < equipSlots.Length; i++)
            {
                if(equipSlots[i].item == null)
                {
                    continue;
                }

                addAttack += equipSlots[i].item.atk;
                addHp += equipSlots[i].item.hp;
            }

            player.addHp = initHp + addHp;
            player.addAttackDamage = initAttack + addAttack; 

            container.isEquip = false;
        }
    }
}
