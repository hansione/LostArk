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

    float hp;
    public float attack;

    public Container container;

    private void Start()
    {
        equipSlots = equipBase.GetComponentsInChildren<Slot>();

        hp = player.hp;
        attack = player.attackDamage;
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

        hpText.text = "체력 : " + hp.ToString("F0");
        attackText.text = "공격력 : " + attack.ToString("F0");
    }

    public void SetStatus()
    {
        if(container.isEquip)
        {
            hp = 100;
            attack = 10;

            for (int i = 0; i < equipSlots.Length; i++)
            {
                if(equipSlots[i].item == null)
                {
                    continue;
                }

                attack += equipSlots[i].item.atk;
                hp += equipSlots[i].item.hp;
            }

            container.isEquip = false;
        }
    }
}
